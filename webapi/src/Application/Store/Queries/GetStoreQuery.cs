using webapi.Application.Common.Interfaces;
using webapi.Application.Store.Queries.DTOs;

namespace webapi.Application.Store.Queries;
public class GetStoreQuery : IRequest<StoreDTO>
{
    public Guid TokenAccess { get; set; }

    public GetStoreQuery(Guid tokenAccess)
    {
        TokenAccess = tokenAccess;
    }
}

public class GetStoreQueryHandler : IRequestHandler<GetStoreQuery, StoreDTO>
{
    private readonly IApplicationDbContext _context;

    public GetStoreQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<StoreDTO> Handle(GetStoreQuery request, CancellationToken cancellationToken)
    {
        var store = await _context.Stores
            .Include(s => s.Categories)
            .ThenInclude(c => c.Products)
            .FirstOrDefaultAsync(s => s.TokenAccess == request.TokenAccess.ToString(), cancellationToken);

        if (store == null)
        {
            // Manejar el caso en que la tienda no se encuentre
            // Puedes lanzar una excepción o devolver un valor específico
        }

        return new StoreDTO
        {
            StoreId = store.StoreId,
            Name = store.Name ?? string.Empty, // Proporciona un valor predeterminado si es null
            Url = store.Url ?? string.Empty,
            Instagram = store.Instagram ?? string.Empty,
            Whatsapp = store.Whatsapp ?? string.Empty,
            Address = store.Address ?? string.Empty,
            ImageUrl = store.ImageUrl ?? string.Empty,
            Categories = store.Categories.Select(c => new CategoryDTO
            {
                CategoryId = c.CategoryId,
                Name = c.Name ?? string.Empty,
                Description = c.Description ?? string.Empty,
                Products = c.Products.Select(p => new ProductDTO
                {
                    ProductId = p.ProductId,
                    Name = p.Name ?? string.Empty,
                    Description = p.Description ?? string.Empty,
                    Price = p.Price, // Asumo que este es un tipo decimal y no necesita el operador ??
                    ProductImage = p.ProductImage ?? string.Empty
                }).ToList()
            }).ToList()
        };

    }
}
