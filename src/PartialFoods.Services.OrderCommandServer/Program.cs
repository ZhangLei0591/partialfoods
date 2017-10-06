using System;
using Grpc.Core;
using PartialFoods.Services;

namespace PartialFoods.Services.OrderCommandServer
{
    class Program
    {
        static void Main(string[] args)
        {
            const int Port = 3000;

            IEventEmitter kafkaEmitter = new KafkaEventEmitter();

            Server server = new Server
            {
                Services = { OrderCommand.BindService(new OrderCommandImpl(kafkaEmitter)) },
                Ports = { new ServerPort("localhost", Port, ServerCredentials.Insecure) }
            };
            server.Start();

            Console.WriteLine("Orders Command RPC Service Listening on Port " + Port);
            Console.WriteLine("Press any key to stop");

            Console.ReadKey();

            server.ShutdownAsync().Wait();
        }
    }
}
