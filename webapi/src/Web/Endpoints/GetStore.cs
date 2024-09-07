

namespace webapi.Web.Endpoints;

public class GetStore : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .RequireAuthorization()
            .MapGet("{storeId}", GetStoreById);
    }

    public async Task<Store> GetStoreById(ISender sender, Guid storeId)
    {
        return await sender.Send(new GetStore(storeId));
    }
}

