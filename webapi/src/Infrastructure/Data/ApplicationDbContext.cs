using System.Reflection;
using webapi.Application.Common.Interfaces;
using webapi.Domain.Entities;
using webapi.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace webapi.Infrastructure.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Store>(entity =>
        {
            entity.HasKey(e => e.StoreId);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Url).HasMaxLength(100);
            entity.Property(e => e.Instagram).HasMaxLength(100);
            entity.Property(e => e.Whatsapp).HasMaxLength(100);
            entity.Property(e => e.Address).HasMaxLength(100);
            entity.Property(e => e.ImageUrl).HasMaxLength(100);
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.TokenAccess).HasColumnType("varchar(max)");

            entity.HasMany(e => e.Products)
                  .WithOne(p => p.Store)
                  .HasForeignKey(p => p.StoreId);

            entity.HasMany(e => e.Categories)
                  .WithOne(c => c.Store)
                  .HasForeignKey(c => c.StoreId);
        });

        builder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Description).HasColumnType("varchar(max)");
            entity.Property(e => e.Price).HasColumnType("decimal(12, 2)");
            entity.Property(e => e.ProductImage).HasColumnType("varchar(max)");

            entity.HasOne(p => p.Category)
                  .WithMany(c => c.Products)
                  .HasForeignKey(p => p.CategoryId)
                  .OnDelete(DeleteBehavior.SetNull);
        });

        builder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Description).HasMaxLength(100);

            entity.HasMany(c => c.Products)
                  .WithOne(p => p.Category)
                  .HasForeignKey(p => p.CategoryId);
        });
    }
}
