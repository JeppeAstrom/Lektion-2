using Microsoft.EntityFrameworkCore;
using WebApi.Models.Entities;

namespace _01_ASPNetMVC.Services
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
        {
        }

        public DbSet<ProductEntity> Products { get; set; }
    }
}
