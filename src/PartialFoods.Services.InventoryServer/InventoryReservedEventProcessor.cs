using PartialFoods.Services.InventoryServer.Entities;

namespace PartialFoods.Services.InventoryServer
{
    public class InventoryReservedEventProcessor
    {
        private IInventoryRepository repository;

        public InventoryReservedEventProcessor(IInventoryRepository repository)
        {
            this.repository = repository;
        }

        public bool HandleInventoryReservedEvent(InventoryReservedEvent evt)
        {
            return true;
        }
    }
}