using Newtonsoft.Json;

namespace PartialFoods.Services.OrderCommandServer
{
    public class InventoryReservedEvent
    {
        [JsonProperty("sku")]
        public string SKU { get; set; }

        [JsonProperty("quantity")]
        public uint Quantity { get; set; }

        [JsonProperty("reserved_on")]
        public ulong ReservedOn { get; set; }

        [JsonProperty("order_id")]
        public string OrderID { get; set; }

        [JsonProperty("user_id")]
        public string UserID { get; set; }

        [JsonProperty("event_id")]
        public string EventID { get; set; }
    }
}