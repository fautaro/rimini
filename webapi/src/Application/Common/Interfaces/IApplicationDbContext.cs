using webapi.Domain.Entities;

namespace webapi.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Domain.Entities.Store> Stores { get; set; }
    DbSet<Product> Products { get; set; }
    DbSet<Category> Categories { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
