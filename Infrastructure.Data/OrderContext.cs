using Domain.Core;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class OrderContext : DbContext 
    {
        public OrderContext(DbContextOptions options) : base(options) { }

        public DbSet<Book> Books { get; set; }
        
        public DbSet<Order> Orders { get; set; }
    }
}
