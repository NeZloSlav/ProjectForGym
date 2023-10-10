using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectForGym.Models
{
    public class ProductContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Tariff> Tariffs { get; set; }
        public DbSet<MarkDate> MarkDates { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-SSLBIEJ\\SQLEXPRESS");
            optionsBuilder.UseLazyLoadingProxies();

        }
    }
}
