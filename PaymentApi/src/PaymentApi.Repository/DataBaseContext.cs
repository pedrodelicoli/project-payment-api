using Microsoft.EntityFrameworkCore;
using PaymentApi.Domain;

namespace PaymentApi.Repository
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {
        }

        public DbSet<Item> Itens { get; set; } 
        public DbSet<Seller> Sellers { get; set; }
        public DbSet<Sale> Sales { get; set; }
        
    }
}
