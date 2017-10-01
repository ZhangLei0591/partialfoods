using System;
using PartialFoods.CommandService;
using PartialFoods.Services;
using System.Collections.Generic;

namespace PartialFoods.CommandService.Tests
{
    public class FakeEventEmitter : IEventEmitter
    {
        public FakeEventEmitter()
        {
            this.EmittedTransactions = new List<PointOfSaleTransaction>();
            this.NextEmitResult = true;
        }

        public bool EmitTransactionAcceptedEvent(PointOfSaleTransaction sourceTransaction)
        {
            if (this.NextEmitResult)
            {
                this.EmittedTransactions.Add(sourceTransaction);
            }
            return this.NextEmitResult;
        }

        public List<PointOfSaleTransaction> EmittedTransactions { get; set; }
        public bool NextEmitResult { get; set; }
    }
}