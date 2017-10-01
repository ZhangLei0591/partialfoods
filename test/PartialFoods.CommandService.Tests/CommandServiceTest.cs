using System;
using Google.Protobuf.Collections;
using PartialFoods.Services;
using Xunit;

namespace PartialFoods.CommandService.Tests
{
    public class CommandServiceTest
    {
        [Fact]
        public void SubmittingValidTransactionInvokesEmitter()
        {
            var emitter = new FakeEventEmitter();
            var service = new PointOfSaleImpl(emitter);
            var tx = GenerateFakeTransaction(true);

            var result = service.SubmitTransaction(tx, null).Result;

            Assert.True(result.Accepted);
            Assert.NotNull(result.AckID);
            Assert.Equal(1, emitter.EmittedTransactions.Count);
        }

        [Fact]
        public void SubmittingBadTransactionDoesNotEmitEvent()
        {
            var emitter = new FakeEventEmitter();
            var service = new PointOfSaleImpl(emitter);
            var tx = GenerateFakeTransaction(false);

            var result = service.SubmitTransaction(tx, null).Result;

            Assert.False(result.Accepted);
            Assert.Equal(0, emitter.EmittedTransactions.Count);
        }

        [Fact]
        public void FailureToEmitResultsInUnacceptedTransaction()
        {
            var emitter = new FakeEventEmitter();
            emitter.NextEmitResult = false;
            var service = new PointOfSaleImpl(emitter);
            var tx = GenerateFakeTransaction(true);

            var result = service.SubmitTransaction(tx, null).Result;

            Assert.False(result.Accepted);
            Assert.Equal(0, emitter.EmittedTransactions.Count);
        }

        private PointOfSaleTransaction GenerateFakeTransaction(bool valid)
        {
            var tx = new PointOfSaleTransaction
            {
                TaxRate = 99,
                TransactionID = Guid.NewGuid().ToString(),
                StationID = Guid.NewGuid().ToString(),
                LocationID = Guid.NewGuid().ToString(),
                CreatedOn = (ulong)DateTime.UtcNow.Ticks,
            };
            if (valid)
            {
                tx.TaxRate = 5;
                tx.LineItems.Add(new LineItem { SKU = "ABC123", UnitPrice = 12, Quantity = 1 });
                tx.LineItems.Add(new LineItem { SKU = "FYI555", UnitPrice = 200, Quantity = 5 });
            }

            return tx;
        }
    }
}
