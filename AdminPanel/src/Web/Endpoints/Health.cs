using Microsoft.AspNetCore.Mvc;
using webapi.Application.Common.Models;

namespace webapi.Web.Endpoints;

public class Health : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .MapGet("token", Ping);
    }

    public string Ping(ISender sender, string token)
    {
        return "API is running";
    }
}
