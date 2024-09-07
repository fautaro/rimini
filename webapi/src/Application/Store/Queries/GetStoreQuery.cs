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
        }

        return new StoreDTO
        {
            StoreId = store.StoreId,
            Name = store.Name,
            Url = store.Url,
            Instagram = store.Instagram,
            Whatsapp = store.Whatsapp,
            Address = store.Address,
            ImageUrl = store.ImageUrl,
            Categories = store.Categories.Select(c => new CategoryDTO
            {
                CategoryId = c.CategoryId,
                Name = c.Name,
                Description = c.Description,
                Products = c.Products.Select(p => new ProductDTO
                {
                    ProductId = p.ProductId,
                    Name = p.Name,
                    Description = p.Description,
                    Price = p.Price,
                    ProductImage = p.ProductImage
                }).ToList()
            }).ToList()
        };
    }
}
