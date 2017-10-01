using System;
using Grpc.Core;
using PartialFoods.Services;

namespace PartialFoods.SamplePosClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Channel channel = new Channel("127.0.0.1:3000", ChannelCredentials.Insecure);
            
            var client = new PointOfSaleCommand.PointOfSaleCommandClient(channel);

            var tx = new PointOfSaleTransaction {
                TransactionID = Guid.NewGuid().ToString(),
                StationID = Guid.NewGuid().ToString(),
                UserID = Guid.NewGuid().ToString(),
                CreatedOn = (ulong)DateTime.UtcNow.Ticks,
                LocationID = Guid.NewGuid().ToString(),
                TaxRate = 5                
            };

            var response = client.SubmitTransaction(tx);
            Console.WriteLine("Transaction Accepted - " + response.Accepted + ", AckID - " + response.AckID);
        }
    }
}
