using System;
using PartialFoods.Services;

namespace PartialFoods.Services.OrderCommandServer
{
    public class RabbitEventEmitter : IEventEmitter
    {
        public bool EmitOrderAcceptedEvent(OrderAcceptedEvent evt)
        {
            Console.WriteLine("Emitting order accepted event...");
            evt.OrderID = Guid.NewGuid().ToString();
            return true; // TODO add implementation
        }
    }
}