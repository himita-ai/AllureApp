using AllureApp.Core.Entities;
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

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Optional: configure entities here
    }
}
}
