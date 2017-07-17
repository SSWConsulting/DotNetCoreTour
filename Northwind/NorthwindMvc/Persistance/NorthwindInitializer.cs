using NorthwindMvc.Domain;
using System;
using System.Linq;

namespace NorthwindMvc.Persistance
{
    public class NorthwindInitializer
    {
        public static void Initialize(NorthwindContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            if (!context.Customers.Any())
            {
                Seed(context);
            }
        }

        private static void Seed(NorthwindContext context)
        {
            var customers = new [] {
                new Customer { Name = "SSW", Phone = "(02) 9953 3000", Website = "https://www.ssw.com.au" },
                new Customer { Name = "Microsoft", Phone = "13 20 58", Website = "https://www.microsoft.com" },
                new Customer { Name = "Jetbrains", Phone = "+420 2 4172 2501", Website = "https://www.jetbrains.com" },
            };

            context.Customers.AddRange(customers);
            context.SaveChanges();
        }
    }
}
