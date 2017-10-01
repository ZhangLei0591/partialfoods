using System;
using Grpc.Core;
using PartialFoods.Services;

namespace PartialFoods.CommandService
{
    class Program
    {
        static void Main(string[] args)
        {
            const int Port = 3000;

            IEventEmitter rabbitEmitter = new RabbitEventEmitter();

            Server server = new Server {
                Services = { PointOfSaleCommand.BindService(new PointOfSaleImpl(rabbitEmitter)) },
                Ports = { new ServerPort("localhost", Port, ServerCredentials.Insecure) }
            };
            server.Start();

            Console.WriteLine("Point of Sale RPC Service Listening on Port " + Port);
            Console.WriteLine("Press any key to stop");

            Console.ReadKey();

            server.ShutdownAsync().Wait();
        }
    }
}
