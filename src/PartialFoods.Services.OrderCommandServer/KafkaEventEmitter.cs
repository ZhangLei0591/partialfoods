using System;
using KafkaNet;
using KafkaNet.Model;
using KafkaNet.Protocol;
using Newtonsoft.Json;

namespace PartialFoods.Services.OrderCommandServer
{
    public class KafkaEventEmitter : IEventEmitter
    {
        private const string ORDERS_TOPIC = "orders";
        private const string RESERVED_TOPIC = "inventoryreserved";

        public bool EmitOrderAcceptedEvent(OrderAcceptedEvent evt)
        {
            evt.OrderID = Guid.NewGuid().ToString();
            var options = new KafkaOptions(new Uri("http://localhost:9092"));

            var router = new BrokerRouter(options);
            var client = new Producer(router);

            string messageJson = JsonConvert.SerializeObject(evt);
            Console.WriteLine($"Emitting Order Accepted Event {evt.OrderID}");
            client.SendMessageAsync(ORDERS_TOPIC, new[] { new Message(messageJson) }).Wait();

            return true;
        }

        public bool EmitInventoryReservedEvent(InventoryReservedEvent evt)
        {
            evt.EventID = Guid.NewGuid().ToString();
            var options = new KafkaOptions(new Uri("http://localhost:9092"));

            var router = new BrokerRouter(options);
            var client = new Producer(router);

            string messageJson = JsonConvert.SerializeObject(evt);
            Console.WriteLine($"Emitting Inventory Reserved Event for Order {evt.OrderID}, SKU {evt.SKU}");
            client.SendMessageAsync(RESERVED_TOPIC, new[] { new Message(messageJson) }).Wait();

            return true;
        }
    }
}