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
        public override Task<TransactionSubmissionResponse> SubmitTransaction(PointOfSaleTransaction request, grpc::ServerCallContext context)
        {
            Console.WriteLine("Handling POS Transaction Submission...");
            var response = new TransactionSubmissionResponse();
            response.AckID = Guid.NewGuid().ToString();
            response.Accepted = true;            
            
            return Task.FromResult(response);
        }
    }
}