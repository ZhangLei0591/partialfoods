using Microsoft.AspNetCore.Mvc;
using System.Linq;
using PartialFoods.Services.APIServer.Models;

namespace PartialFoods.Services.APIServer.Controllers
{
    [Route("api/[controller]")]
    public class OrdersController : Controller
    {
        private OrderManagement.OrderManagementClient orderManagementClient;

        public OrdersController(OrderManagement.OrderManagementClient client) : base()
        {
            this.orderManagementClient = client;
        }

        [HttpGet("{orderid}")]
        public OrderDetails GetOrder(string orderid)
        {
            var internalOrder = orderManagementClient.GetOrder(new GetOrderRequest { OrderID = orderid });

            OrderDetails response = new OrderDetails
            {
                OrderID = internalOrder.OrderID,
                CreatedOn = internalOrder.CreatedOn,
                TaxRate = internalOrder.TaxRate,
                LineItems = (
                    from li in internalOrder.LineItems
                    select new OrderItem
                    {
                        SKU = li.SKU,
                        Quantity = li.Quantity,
                        UnitPrice = li.UnitPrice
                    }
                ).ToArray()
            };

            return response;
        }
    }
}