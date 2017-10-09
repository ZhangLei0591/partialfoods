using System;
using System.Collections.Generic;
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
            //const int Port = 3002;

            Console.WriteLine("Press any key to stop");
            Console.ReadKey();
        }
    }
}
