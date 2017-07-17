using Microsoft.EntityFrameworkCore;
using NorthwindMvc.Domain;

namespace NorthwindMvc.Persistance
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
