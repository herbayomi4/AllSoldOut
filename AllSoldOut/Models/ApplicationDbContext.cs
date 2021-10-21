using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AllSoldOut.ViewModel;
using AllSoldOut.Models;

namespace AllSoldOut.Models
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            :base(options)
        {

        }
        public DbSet<Customer> customers { get; set; }
        public DbSet<Role> roles { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<Specifications> specifications { get; set; }
        public DbSet<PhoneMaker> phoneMakers { get; set; }
        public DbSet<Sales> sales { get; set; }
        public DbSet<User> users { get; set; }
        public DbSet<AllSoldOut.ViewModel.PhoneDetailsViewModel> PhoneListViewModel { get; set; }
        public DbSet<AllSoldOut.ViewModel.PhoneCreateViewModel> PhoneCreateViewModel { get; set; }
        public DbSet<AllSoldOut.ViewModel.CheckoutViewModel> CheckoutViewModel { get; set; }

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

            mb.Entity<User>().HasData(new
            {
                userId = 1,
                firstName = "Admin",
                lastName = "Admin",
                email = "admin@admin",
                password = PasswordHash.Hash("admin1234"),
                address = "GTBank",
                city = "Victoria Island",
                contact = "09034582835",
                roleId = 1
            });

            mb.Entity<PhoneMaker>().HasData(new
            {
                makerId = 1,
                makerName = "Apple",
                makerCategory = "Iphone"
            },
            new
            {
                makerId = 2,
                makerName = "Samsung",
                makerCategory = "Android"
            },
            new
            {
                makerId = 3,
                makerName = "Tecno",
                makerCategory = "Android"
            },
            new
            {
                makerId = 4,
                makerName = "Infinix",
                makerCategory = "Android"
            },
            new
            {
                makerId = 5,
                makerName = "Itel",
                makerCategory = "Android"
            },
            new
            {
                makerId = 6,
                makerName = "Nokia",
                makerCategory = "Android"
            });
        }


    }
}
