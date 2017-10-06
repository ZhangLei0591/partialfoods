using System;
using KafkaNet;
using KafkaNet.Model;
using KafkaNet.Protocol;
using Newtonsoft.Json;

namespace PartialFoods.Services.OrderCommandServer
{
    public class KafkaEventEmitter : IEventEmitter
    {
        public bool EmitOrderAcceptedEvent(OrderAcceptedEvent evt)
        {
            evt.OrderID = Guid.NewGuid().ToString();
            var options = new KafkaOptions(new Uri("http://localhost:9092"));

            var router = new BrokerRouter(options);
            var client = new Producer(router);

            string messageJson = JsonConvert.SerializeObject(evt);

            client.SendMessageAsync("orders", new[] { new Message(messageJson) }).Wait();

            return true;
        }
    }
}