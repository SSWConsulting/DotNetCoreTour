using Microsoft.EntityFrameworkCore;
using NorthwindTraders.NorthwindMvc.Domain;

namespace NorthwindTraders.NorthwindMvc.Persistance
{
    public class NorthwindContext : DbContext
    {
        public NorthwindContext (DbContextOptions<NorthwindContext> options)
            : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
    }
}
