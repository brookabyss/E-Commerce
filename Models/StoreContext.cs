
using Microsoft.EntityFrameworkCore;
 
namespace Commerce.Models
{
    public class StoreContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public StoreContext(DbContextOptions<StoreContext> options) : base(options) { }
        public DbSet<Products> Products {get;set;}
        public DbSet<Customers> Customers {get;set;}
        public DbSet<Orders> Orders {get;set;}
    }
}