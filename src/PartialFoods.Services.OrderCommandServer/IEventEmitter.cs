using System.Collections.Generic;
using Newtonsoft.Json;
using PartialFoods.Services;

namespace PartialFoods.Services.OrderCommandServer
{
    public interface IEventEmitter
    {
        bool EmitOrderAcceptedEvent(OrderAcceptedEvent evt);
    }
}