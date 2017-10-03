using System.Collections.Generic;
using Newtonsoft.Json;
using PartialFoods.Services;

namespace PartialFoods.CommandService
{
    public interface IEventEmitter
    {
        bool EmitOrderAcceptedEvent(OrderAcceptedEvent evt);
    }
}