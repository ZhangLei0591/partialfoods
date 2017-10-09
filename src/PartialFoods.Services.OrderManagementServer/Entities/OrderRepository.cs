using System;
using System.Linq;

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
            Console.WriteLine($"Adding order {order.OrderID} to repository.");
            try
            {
                var existing = context.Orders.FirstOrDefault(o => o.OrderID == order.OrderID);
                if (existing != null)
                {
                    Console.WriteLine($"Bypassing add for order {order.OrderID} - already exists.");
                    return order;
                }
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