using PartialFoods.Services;

namespace PartialFoods.CommandService
{
    public interface IEventEmitter 
    {
        bool EmitTransactionAcceptedEvent(PointOfSaleTransaction sourceTransaction);
    }
}