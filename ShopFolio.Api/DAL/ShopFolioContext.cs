using Microsoft.EntityFrameworkCore;
using ShopFolio.Api.Models;

namespace ShopFolio.Api.DAL
{
    public class ShopFolioDbContext : DbContext
    {
        public ShopFolioDbContext(DbContextOptions<ShopFolioDbContext> options) : base(options)
        { }
        public DbSet<Product> Products { get; set; }
        public DbSet<CustomField> CustomFields { get; set; }
        public DbSet<FieldType> FieldTypes { get; set; }
    }
}