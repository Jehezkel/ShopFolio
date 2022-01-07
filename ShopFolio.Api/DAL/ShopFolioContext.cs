// using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShopFolio.Api.Models;

namespace ShopFolio.Api.DAL
{
    public class ShopFolioDbContext : IdentityDbContext<AppUser>
    {
        public ShopFolioDbContext(DbContextOptions<ShopFolioDbContext> options) : base(options)
        { }
        public DbSet<Product> Products { get; set; }
        public DbSet<CustomField> CustomFields { get; set; }
        public DbSet<FieldType> FieldTypes { get; set; }
        public DbSet<FieldToValue> FieldToValues { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<FieldToValue>().HasKey(fv => new { fv.CustomFieldID, fv.ProductID });
        }
    }
}