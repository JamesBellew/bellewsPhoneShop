using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bellewsPhoneShop.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using bellewsPhoneShop.Models;
using static System.Net.Mime.MediaTypeNames;

namespace bellewsPhoneShop.Data
{
    public class AuthDbContext : IdentityDbContext<ApplicationUser>
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options)
            : base(options)
        {
        }
        public DbSet<Phone> Phones { get; set; }
        public DbSet<ImageModel> Images { get; set; }

        public DbSet<Case> Cases { get; set; }

        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
        public DbSet<Charger> Chargers { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
     
    }
}
