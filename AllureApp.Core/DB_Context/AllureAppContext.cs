using AllureApp.Core.Entities;
using AllureStore.Core.Config;
using AllureStore.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AllureApp.Core.DBContext
{
    public class AllureAppContext : DbContext
{
    public AllureAppContext(DbContextOptions<AllureAppContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
      public DbSet<AdminNavItem> AdminNavItems { get; set; }
        public DbSet<AdminRole> AdminRole { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<CartItem>CartItems { get; set; }
        public DbSet<PaymentDetails> PaymentDetails { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        public void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserMapConfig());
        }
    }
}
