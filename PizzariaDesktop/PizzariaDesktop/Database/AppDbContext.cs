using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PizzariaDesktop.Models;
using static MaterialDesignThemes.Wpf.Theme.ToolBar;

namespace PizzariaDesktop.Database
{
    internal class AppDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderLine> OrderLines { get; set; }
        public DbSet<Pizza> Pizzas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            if (!optionsBuilder.IsConfigured)
            {
                string connstr = ConfigurationManager.ConnectionStrings["MyConnStr"].ConnectionString;
                optionsBuilder.UseSqlite(connstr);
            }
        }
    }
}
