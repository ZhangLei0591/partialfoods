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
            this.EmittedTransactions = new List<PointOfSaleTransactionAcceptedEvent>();
            this.NextEmitResult = true;
        }

        public bool EmitTransactionAcceptedEvent(PointOfSaleTransactionAcceptedEvent evt)
        {
            if (this.NextEmitResult)
            {
                evt.AcknowledgementID = Guid.NewGuid().ToString();
                this.EmittedTransactions.Add(evt);
            }
            return this.NextEmitResult;
        }

        public List<PointOfSaleTransactionAcceptedEvent> EmittedTransactions { get; set; }
        public bool NextEmitResult { get; set; }
    }
}