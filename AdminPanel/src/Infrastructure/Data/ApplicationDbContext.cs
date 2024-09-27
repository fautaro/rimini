using Domain.Entities;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using webapi.Application.Common.Interfaces;
using webapi.Domain.Entities;

namespace webapi.Infrastructure.Data;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Store> Store { get; set; }
    public DbSet<Product> Product { get; set; }
    public DbSet<Category> Category { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Store>(entity =>
        {
            entity.HasKey(e => e.store_id);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Url).HasMaxLength(100);
            entity.Property(e => e.Instagram).HasMaxLength(100);
            entity.Property(e => e.Whatsapp).HasMaxLength(100);
            entity.Property(e => e.Address).HasMaxLength(100);
            entity.Property(e => e.ImageUrl).HasMaxLength(100);
            entity.Property(e => e.created_at).HasColumnType("datetime");
            entity.Property(e => e.TokenAccess).HasColumnType("varchar(max)");

            entity.HasMany(e => e.Products)
                  .WithOne(p => p.Store)
                  .HasForeignKey(p => p.Store_id);

            entity.HasMany(e => e.Categories)
                  .WithOne(c => c.Store)
                  .HasForeignKey(c => c.Store_id);
        });

        builder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Product_id);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Description).HasColumnType("varchar(max)");
            entity.Property(e => e.Price).HasColumnType("decimal(12, 2)");
            entity.Property(e => e.Product_Image).HasColumnType("varchar(max)");

            entity.HasOne(p => p.Category)
                  .WithMany(c => c.Products)
                  .HasForeignKey(p => p.Category_id)
                  .OnDelete(DeleteBehavior.SetNull);
        });

        builder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Category_id);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Description).HasMaxLength(100);

            entity.HasMany(c => c.Products)
                  .WithOne(p => p.Category)
                  .HasForeignKey(p => p.Category_id);
        });

        builder.Entity<User>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Created).HasColumnName("created");
            entity.Property(e => e.Email).HasColumnName("email");
            entity.Property(e => e.First_Name).HasColumnName("first_name");
            entity.Property(e => e.Last_Name).HasColumnName("last_name");
            entity.Property(e => e.Password).HasColumnName("password");
            entity.Property(e => e.Updated).HasColumnName("updated");
            entity.Property(e => e.Username).HasColumnName("username");
            entity.Property(e => e.Role).HasColumnName("role");
            entity.Property(e => e.Active).HasColumnName("active");
            entity.Property(e => e.StoreId).HasColumnName("StoreId");

        });
    }
}
