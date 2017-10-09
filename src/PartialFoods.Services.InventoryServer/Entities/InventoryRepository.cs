using System;
using System.Linq;

namespace PartialFoods.Services.InventoryServer.Entities
{
    public class InventoryRepository : IInventoryRepository
    {
        private InventoryContext context;

        public InventoryRepository(InventoryContext context)
        {
            this.context = context;
        }

        public int GetCurrentQuantity(string sku)
        {
            try
            {
                var product = context.Products.FirstOrDefault(p => p.SKU == sku);
                if (product != null)
                {
                    var productActivities = (from activity in context.Activities
                                             where activity.SKU == sku
                                             orderby activity.CreatedOn
                                             select activity).ToArray();

                    // Reserve and Ship decrease qty, release a reservation increases
                    return productActivities.Aggregate(product.OriginalQuantity, (qty, next) =>
                        (next.ActivityType == ActivityType.Reserved || next.ActivityType == ActivityType.Shipped) ?
                            qty - next.Quantity : qty + next.Quantity
                    );
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                Console.WriteLine($"Failed to query current quantity: {ex.ToString()}");
            }
            return 0;
        }

        public Product GetProduct(string sku)
        {
            try
            {
                var product = context.Products.FirstOrDefault(p => p.SKU == sku);
                return product;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                Console.WriteLine($"Failed to query product - {sku}");
            }
            return null;
        }

        public ProductActivity PutActivity(ProductActivity activity)
        {
            Console.WriteLine($"Attempting to put activity {activity.ActivityID}, type {activity.ActivityType.ToString()}");

            try
            {
                var existing = context.Activities.FirstOrDefault(a => a.ActivityID == activity.ActivityID);
                if (existing != null)
                {
                    Console.WriteLine($"Bypassing add for order activity {activity.ActivityID} - already exists.");
                    return activity;
                }
                context.Add(activity);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to store activity {ex.ToString()}");
                Console.WriteLine(ex.StackTrace);
                return null;
            }
            return activity;
        }
    }
}