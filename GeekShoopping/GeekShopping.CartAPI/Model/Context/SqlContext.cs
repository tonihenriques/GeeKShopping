using Microsoft.EntityFrameworkCore;

namespace GeekShopping.CartAPI.Model.Context
{
    public class SqlContext : DbContext
    {
        public SqlContext() {}
        public SqlContext(DbContextOptions<SqlContext> options) : base(options) {}

        public DbSet<Product> Products { get; set; }
        public DbSet<CartDetail> CartDetail { get; set; }
        public DbSet<CartHeader> CartHeader { get; set; }

       
    }
}
