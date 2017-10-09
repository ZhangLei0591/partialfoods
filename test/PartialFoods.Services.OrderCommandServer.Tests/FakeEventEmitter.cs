using System;
using PartialFoods.Services;
using System.Collections.Generic;
using PartialFoods.Services.OrderCommandServer;

namespace PartialFoods.CommandService.Tests
{
    public class FakeEventEmitter : IEventEmitter
    {
        public FakeEventEmitter()
        {
            this.EmittedTransactions = new List<OrderAcceptedEvent>();
            this.EmittedInventoryReservedEvents = new List<InventoryReservedEvent>();
            this.NextEmitResult = true;
        }

        public bool EmitOrderAcceptedEvent(OrderAcceptedEvent evt)
        {
            if (this.NextEmitResult)
            {
                evt.OrderID = Guid.NewGuid().ToString();
                this.EmittedTransactions.Add(evt);
            }
            return this.NextEmitResult;
        }

        public bool EmitInventoryReservedEvent(InventoryReservedEvent evt)
        {
            if (this.NextEmitResult)
            {
                this.EmittedInventoryReservedEvents.Add(evt);
            }
            return this.NextEmitResult;
        }

        public List<OrderAcceptedEvent> EmittedTransactions { get; set; }
        public List<InventoryReservedEvent> EmittedInventoryReservedEvents { get; set; }
        public bool NextEmitResult { get; set; }
    }
}