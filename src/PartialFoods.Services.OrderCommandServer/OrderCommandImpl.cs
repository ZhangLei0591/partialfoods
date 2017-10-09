using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Grpc.Core.Utils;
using grpc = global::Grpc.Core;
using PartialFoods.Services;
using Google.Protobuf; // required for byte array extension

namespace PartialFoods.Services.OrderCommandServer
{
    public class OrderCommandImpl : OrderCommand.OrderCommandBase
    {
        private IEventEmitter eventEmitter;

        public OrderCommandImpl(IEventEmitter emitter)
        {
            eventEmitter = emitter;
        }

        public override Task<OrderResponse> SubmitOrder(OrderRequest request, grpc::ServerCallContext context)
        {
            Console.WriteLine("Handling Order Request Submission");
            var response = new OrderResponse();

            if (!isValidRequest(request))
            {
                response.Accepted = false;
                return Task.FromResult(response);
            }

            var evt = OrderAcceptedEvent.FromProto(request);

            if (eventEmitter.EmitOrderAcceptedEvent(evt))
            {
                foreach (var li in evt.LineItems)
                {
                    var reservedEvent = new InventoryReservedEvent
                    {
                        OrderID = evt.OrderID,
                        ReservedOn = (ulong)DateTime.UtcNow.Ticks,
                        SKU = li.SKU,
                        Quantity = li.Quantity,
                        UserID = evt.UserID
                    };
                    if (!eventEmitter.EmitInventoryReservedEvent(reservedEvent))
                    {
                        response.Accepted = false;
                        return Task.FromResult(response);
                    }
                }
                response.OrderID = evt.OrderID;
                response.Accepted = true;
            }
            else
            {
                response.Accepted = false;
            }
            return Task.FromResult(response);
        }

        private bool isValidRequest(OrderRequest request)
        {
            if (request.LineItems.Count == 0)
            {
                return false;
            }
            if (request.TaxRate > 50)
            {
                return false;
            }

            return true;
        }
    }
}