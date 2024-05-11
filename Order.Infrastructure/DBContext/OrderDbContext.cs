using Microsoft.EntityFrameworkCore;
using Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Infrastructure.DBContext
{
    public class OrderDbContext : DbContext
    {
        public OrderDbContext(DbContextOptions<OrderDbContext> options) : base(options)
        {

        }

        public DbSet<Product> Product { get; set; }
        public DbSet<Orders> Order { get; set; }
        public DbSet<RegisterModel> RegisterModel { get; set; }
        public DbSet<UserRoles> UserRole { get; set; }
        public DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<User>().Property(b => b.FirstName).IsRequired(false);
            builder.Entity<User>().Property(b => b.LastName).IsRequired(false);
            builder.Entity<User>().Property(b => b.Token).IsRequired(false);
            builder.Entity<User>().Property(b => b.Role).IsRequired(false);
        }
    }
}
