﻿using System;
using System.Threading.Tasks;
using Grpc.Core;
using System.Linq;
using System.Collections.Generic;
using Confluent.Kafka;
using Confluent.Kafka.Serialization;
using System.Text;
using PartialFoods.Services.OrderManagementServer.Entities;

namespace PartialFoods.Services.OrderManagementServer
{
    class Program
    {
        static void Main(string[] args)
        {
            string brokerList = "localhost:9092";
            const string topic = "orders";

            var config = new Dictionary<string, object>
            {
                { "group.id", "order-management" },
                { "enable.auto.commit", false },
                { "bootstrap.servers", brokerList }
            };
            var context = new OrdersContext();
            var repo = new OrderRepository(context);
            var eventProcessor = new OrderAcceptedEventProcessor(repo);
            var kafkaConsumer = new KafkaOrdersConsumer(topic, config, eventProcessor);
            kafkaConsumer.Consume();
            const int Port = 3001;

            Server server = new Server
            {
                Services = { OrderManagement.BindService(new OrderManagementImpl()) },
                Ports = { new ServerPort("localhost", Port, ServerCredentials.Insecure) }
            };
            server.Start();
            Console.WriteLine("Order management RPC service listening on port " + Port);
            Console.WriteLine("Press any key to stop");


            Console.ReadKey();
            server.ShutdownAsync().Wait();
        }
    }
}
