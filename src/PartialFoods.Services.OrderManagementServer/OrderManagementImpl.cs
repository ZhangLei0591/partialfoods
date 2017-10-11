using System;
using System.Linq;
using System.Threading.Tasks;
using PartialFoods.Services;
using Grpc.Core.Utils;
using grpc = global::Grpc.Core;
using PartialFoods.Services.OrderManagementServer.Entities;

namespace PartialFoods.Services.OrderManagementServer
{
    public class OrderManagementImpl : OrderManagement.OrderManagementBase
    {
        private IOrderRepository repository;

        public OrderManagementImpl(IOrderRepository repository)
        {
            this.repository = repository;
        }
        public override Task<GetOrderResponse> GetOrder(GetOrderRequest request, grpc::ServerCallContext context)
        {
            GetOrderResponse response = new GetOrderResponse();

            Order order = repository.GetOrder(request.OrderID);
            if (order != null)
            {
                response.OrderID = order.OrderID;
                response.CreatedOn = (ulong)order.CreatedOn;
                response.TaxRate = (uint)order.TaxRate;
                foreach (var li in order.LineItems)
                {
                    response.LineItems.Add(new LineItem
                    {
                        SKU = li.SKU,
                        Quantity = (uint)li.Quantity,
                        UnitPrice = (uint)li.UnitPrice,
                    });
                }
            }

            return Task.FromResult(response);
        }
    }
}