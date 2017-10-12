namespace PartialFoods.Services.OrderManagementServer.Entities
{
    public interface IOrderRepository
    {
        Order Add(Order order);
        Order GetOrder(string orderID);

        bool OrderExists(string orderID);
    }
}