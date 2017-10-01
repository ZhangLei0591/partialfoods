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

namespace PartialFoods.CommandService
{
    public class PointOfSaleImpl : PointOfSaleCommand.PointOfSaleCommandBase
    {
        private IEventEmitter eventEmitter;

        public PointOfSaleImpl(IEventEmitter emitter)
        {
            eventEmitter = emitter;
        }

        public override Task<TransactionSubmissionResponse> SubmitTransaction(PointOfSaleTransaction request, grpc::ServerCallContext context)
        {
            Console.WriteLine("Handling POS Transaction Submission...");
            var response = new TransactionSubmissionResponse();

            if (!isValidRequest(request))
            {
                response.Accepted = false;
                return Task.FromResult(response);
            }

            var evt = PointOfSaleTransactionAcceptedEvent.FromProto(request);
            if (eventEmitter.EmitTransactionAcceptedEvent(evt))
            {
                response.AckID = evt.AcknowledgementID;
                response.Accepted = true;
            }
            else
            {
                response.Accepted = false;
            }

            return Task.FromResult(response);
        }

        private bool isValidRequest(PointOfSaleTransaction request)
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