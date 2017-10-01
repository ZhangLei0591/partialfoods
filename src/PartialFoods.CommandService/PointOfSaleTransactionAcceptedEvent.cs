using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using PartialFoods.Services;

namespace PartialFoods.CommandService
{

    public class PointOfSaleTransactionAcceptedEvent
    {
        [JsonProperty("transaction_id")]
        public string TransactionID;
        [JsonProperty("station_id")]
        public string StationID;

        [JsonProperty("created_on")]
        public ulong CreatedOn;

        [JsonProperty("user_id")]
        public string UserID;

        [JsonProperty("location_id")]
        public string LocationID;

        [JsonProperty("tax_rate")]
        public uint TaxRate;

        [JsonProperty("ack_id")]
        public string AcknowledgementID;

        [JsonProperty("line_items")]
        public ICollection<EventLineItem> LineItems;

        public static PointOfSaleTransactionAcceptedEvent FromProto(PointOfSaleTransaction tx)
        {
            var evt = new PointOfSaleTransactionAcceptedEvent
            {
                TaxRate = tx.TaxRate,
                StationID = tx.StationID,
                TransactionID = tx.TransactionID,
                LocationID = tx.LocationID,
                CreatedOn = tx.CreatedOn,
                UserID = tx.UserID
            };
            evt.LineItems = new List<EventLineItem>();
            foreach (LineItem li in tx.LineItems)
            {
                evt.LineItems.Add(new EventLineItem
                {
                    SKU = li.SKU,
                    Quantity = li.Quantity,
                    UnitPrice = li.UnitPrice
                });
            }

            return evt;
        }

    }

    public class EventLineItem
    {
        [JsonProperty("sku")]
        public string SKU;

        [JsonProperty("unit_price")]
        public uint UnitPrice;

        [JsonProperty("quantity")]
        public uint Quantity;
    }
}