using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab7.Entity;

namespace Lab7
{
    internal class DataContext : DbContext
    {
        /* public DataContext([NotNullAttribute] DbContextOptions options) : base(options)
         {
         }*/

        public DbSet<Film> Film { get; set; }

        /*        public DataContext(DbContextOptions<DataContext> options) : base(options)
                {
                }*/

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=lab7;Username=postgres;Password=1111;");
        }

        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }*/
    }
}
