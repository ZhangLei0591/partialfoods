using System;
using System.Threading.Tasks;
using PartialFoods.Services;
using Grpc.Core.Utils;
using grpc = global::Grpc.Core;

namespace PartialFoods.Services.OrderManagementServer
{
    public class OrderManagementImpl : OrderManagement.OrderManagementBase
    {
        public override Task<GetOrderResponse> GetOrder(GetOrderRequest request, grpc::ServerCallContext context)
        {
            GetOrderResponse response = new GetOrderResponse();

            return Task.FromResult(response);
        }
    }
}