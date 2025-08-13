using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BethanysPieShop.Models
{
    public class BethanysPieShopDbContext : IdentityDbContext
    {
        public BethanysPieShopDbContext(DbContextOptions<BethanysPieShopDbContext> options)
            : base(options)
        {
        }
        public DbSet<Pie> Pies { get; set; } = default!;
        public DbSet<Category> Categories { get; set; } = default!;
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; } = default!;
        public DbSet<Order> Orders { get; set; } = default!;
        public DbSet<OrderDetail> OrderDetails { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Pie>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Pies)
                .HasForeignKey(p => p.CategoryId);
        }
    }
}
