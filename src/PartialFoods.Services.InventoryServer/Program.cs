using System;
using System.Collections.Generic;
using Grpc.Core;
using PartialFoods.Services.InventoryServer.Entities;

namespace PartialFoods.Services.InventoryServer
{
    class Program
    {
        static void Main(string[] args)
        {
            string brokerList = "localhost:9092";
            const string topic = "inventoryreserved";

            var config = new Dictionary<string, object>
            {
                { "group.id", "inventory-server" },
                { "enable.auto.commit", false },
                { "bootstrap.servers", brokerList }
            };
            var context = new InventoryContext();
            var repo = new InventoryRepository(context);
            var eventProcessor = new InventoryReservedEventProcessor(repo);
            var kafkaConsumer = new KafkaActivityConsumer(topic, config, eventProcessor);
            kafkaConsumer.Consume();

            const int Port = 3002;
            Server server = new Server
            {
                Services = { InventoryManagement.BindService(new InventoryManagementImpl(repo)) },
                Ports = { new ServerPort("localhost", Port, ServerCredentials.Insecure) }
            };
            server.Start();

            Console.WriteLine($"Inventory management listening on port {Port}. Press any key to stop");
            Console.ReadKey();
        }
    }
}
