using webapi.Application.Store.Queries;
using webapi.Application.Store.Queries.DTOs;

namespace webapi.Web.Endpoints;

public class GetStore : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .MapGet("{storeId}", GetStoreById);
    }

    public async Task<StoreDTO> GetStoreById(ISender sender, Guid storeId)
    {
        return await sender.Send(new GetStoreQuery(storeId));
    }
}

