using Microsoft.EntityFrameworkCore;
using OrderService.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Data
{
    public class OrderContext:DbContext
    {
        public DbSet<Order> Orders { get; set; }

        public OrderContext()
        {

        }

        public OrderContext(DbContextOptions options):base(options)
        {
                
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>(entity => {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.CustomerFullName).IsRequired();
            });
        }
    }
}
