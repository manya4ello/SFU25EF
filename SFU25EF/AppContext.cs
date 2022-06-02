using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;


namespace SFU25EF
{
    public class AppContext : DbContext
    {
        // Объекты таблицы Users
        public DbSet<User> Users { get; set; }

        // Объекты таблицы Companies
        public DbSet<Company> Companies { get; set; }

        public AppContext()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source = OFLT-EAPR5KFR\SQLEXPRESS; Database=EF; Trusted_Connection=True;");
        }
    }
}
