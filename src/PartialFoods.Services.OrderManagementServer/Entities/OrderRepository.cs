using System;

namespace PartialFoods.Services.OrderManagementServer.Entities
{
    public class OrderRepository : IOrderRepository
    {
        private OrdersContext context;

        public OrderRepository(OrdersContext context)
        {
            this.context = context;
        }

        public Order Add(Order order)
        {
            Console.WriteLine("Trying to add an order to repo");
            try
            {
                context.Add(order);
                context.SaveChanges();
                return order;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                Console.WriteLine($"Failed to save changes in db context: {ex.ToString()}");
                return null;
            }
        }
    }
}