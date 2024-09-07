using webapi.Domain.Entities;

namespace webapi.Application.Common.Interfaces;

public interface IApplicationDbContext
{

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
