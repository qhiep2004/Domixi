using Microsoft.EntityFrameworkCore;
using MVC04.Models;
namespace MVC04.Data{
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>().ToTable("tblProducts"); // Ánh xạ với bảng tblProducts
        modelBuilder.Entity<Product>()
            .Property(p => p.ProductPrice)
            .HasColumnType("decimal(18,2)"); // Đảm bảo kiểu dữ liệu Decimal đúng
    }
}
}