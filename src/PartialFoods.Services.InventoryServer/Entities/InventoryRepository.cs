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