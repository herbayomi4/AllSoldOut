using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllSoldOut.Models
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            :base(options)
        {

        }
        public DbSet<Sales> sales { get; set; }
        public DbSet<Role> roles { get; set; }
        public DbSet<Store> stores { get; set; }
        public DbSet<User> users { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Role>().HasData(new
            {
                roleId = 1,
                roleName = "Admin"
            },
            new
            {
                roleId = 2,
                roleName = "Customer"
            });
        }
    }
}
