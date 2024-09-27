using Domain.Entities;
using webapi.Domain.Entities;

namespace webapi.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Domain.Entities.Store> Store { get; set; }
    DbSet<Product> Product { get; set; }
    DbSet<Category> Category { get; set; }
    DbSet<User> User { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
