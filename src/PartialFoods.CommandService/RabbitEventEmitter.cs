using System;
using PartialFoods.Services;

namespace PartialFoods.CommandService
{
    public class RabbitEventEmitter : IEventEmitter
    {
        public bool EmitTransactionAcceptedEvent(PointOfSaleTransactionAcceptedEvent evt)
        {
            evt.AcknowledgementID = Guid.NewGuid().ToString();
            return true; // TODO add implementation
        }
    }
}