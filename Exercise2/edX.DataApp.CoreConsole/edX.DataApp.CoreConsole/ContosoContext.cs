using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
namespace edX.DataApp.CoreConsole
{
    public class ContosoContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "Data Source=trialdbmarcosserver1.database.windows.net;Initial Catalog=ContosoDB;Persist Security Info=True;User ID=marcosjgserver1;Password=Nonsomus1";
            optionsBuilder.UseSqlServer(connectionString);
        }
        public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<ProductCategory> ProductCategories { get; set; }

    }
}

