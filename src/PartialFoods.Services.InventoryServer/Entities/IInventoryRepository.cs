namespace PartialFoods.Services.InventoryServer.Entities
{
    public interface IInventoryRepository
    {
        ProductActivity PutActivity(ProductActivity activity);
    }
}