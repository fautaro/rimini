using webapi.Application.Common.Interfaces;
using webapi.Application.Store.Queries.DTOs;

namespace webapi.Application.Store.Queries;
public class GetStoreQuery : IRequest<StoreDTO>
{
    public Guid StoreId { get; set; }

    public GetStoreQuery(Guid storeId)
    {
        StoreId = storeId;
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
        var store = await _context.Store
            .Include(s => s.Categories)
            .ThenInclude(c => c.Products)
            .FirstOrDefaultAsync(s => s.TokenAccess == request.StoreId.ToString(), cancellationToken);

        if (store == null)
        {
            throw new ArgumentNullException(nameof(store), "Store cannot be null");
        }

        return new StoreDTO
        {
            StoreId = store.store_id,
            Name = store.Name ?? string.Empty,
            Url = store.Url ?? string.Empty,
            Instagram = store.Instagram ?? string.Empty,
            Whatsapp = store.Whatsapp ?? string.Empty,
            Address = store.Address ?? string.Empty,
            ImageUrl = store.ImageUrl ?? string.Empty,
            Categories = store.Categories.Select(c => new CategoryDTO
            {
                CategoryId = c.Category_id,
                Name = c.Name ?? string.Empty,
                Description = c.Description ?? string.Empty,
                Products = c.Products.Select(p => new ProductDTO
                {
                    ProductId = p.Product_id,
                    Name = p.Name ?? string.Empty,
                    Description = p.Description ?? string.Empty,
                    Price = p.Price,
                    ProductImage = p.Product_Image ?? string.Empty
                }).ToList()
            }).ToList()
        };

    }
}
