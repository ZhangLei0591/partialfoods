using PartialFoods.Services;

namespace PartialFoods.CommandService
{
    public class RabbitEventEmitter : IEventEmitter
    {
        public bool EmitTransactionAcceptedEvent(PointOfSaleTransaction sourceTransaction)
        {
            return true; // TODO add implementation
        }
    }
}