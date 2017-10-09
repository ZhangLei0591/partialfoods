using System;
using Google.Protobuf.Collections;
using PartialFoods.Services;
using PartialFoods.Services.OrderCommandServer;
using Xunit;

namespace PartialFoods.CommandService.Tests
{
    public class CommandServiceTest
    {
        [Fact]
        public void SubmittingValidTransactionInvokesEmitter()
        {
            var emitter = new FakeEventEmitter();
            var service = new OrderCommandImpl(emitter);
            var tx = GenerateFakeTransaction(true);

            var result = service.SubmitOrder(tx, null).Result;

            Assert.True(result.Accepted);
            Assert.NotNull(result.OrderID);
            Assert.Equal(1, emitter.EmittedTransactions.Count);
            Assert.Equal(2, emitter.EmittedInventoryReservedEvents.Count);
            Assert.Equal("ABC123", emitter.EmittedInventoryReservedEvents[0].SKU);
            Assert.Equal("FYI555", emitter.EmittedInventoryReservedEvents[1].SKU);
            Assert.Equal((uint)5, emitter.EmittedInventoryReservedEvents[1].Quantity);
        }

        [Fact]
        public void SubmittingBadTransactionDoesNotEmitEvent()
        {
            var emitter = new FakeEventEmitter();
            var service = new OrderCommandImpl(emitter);
            var tx = GenerateFakeTransaction(false);

            var result = service.SubmitOrder(tx, null).Result;

            Assert.False(result.Accepted);
            Assert.Equal(0, emitter.EmittedTransactions.Count);
        }

        [Fact]
        public void FailureToEmitResultsInUnacceptedTransaction()
        {
            var emitter = new FakeEventEmitter();
            emitter.NextEmitResult = false;
            var service = new OrderCommandImpl(emitter);
            var tx = GenerateFakeTransaction(true);

            var result = service.SubmitOrder(tx, null).Result;

            Assert.False(result.Accepted);
            Assert.Equal(0, emitter.EmittedTransactions.Count);
        }

        private OrderRequest GenerateFakeTransaction(bool valid)
        {
            var tx = new OrderRequest
            {
                TaxRate = 99,
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
