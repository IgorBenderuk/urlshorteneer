using DataService.Entities.DbSet;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<Link> URLS{ get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Link>()
                .HasOne(a => a.User)
                .WithMany(u => u.Links)
                .HasForeignKey(a => a.UserId);


            modelBuilder.Entity<User>()
                .Property(u => u.Role)
                .HasConversion<string>();



        }
    }
}
