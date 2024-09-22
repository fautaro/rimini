using MediatR;
using Microsoft.AspNetCore.Mvc;
using webapi.Application.Store.Queries;
using webapi.Application.Store.Queries.DTOs;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StoreController : ControllerBase
{
    private readonly ISender _sender;

    public StoreController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet("{storeId}")]
    public async Task<ActionResult<StoreDTO>> GetStoreById(Guid storeId)
    {
        var store = await _sender.Send(new GetStoreQuery(storeId));

        if (store == null)
            return NotFound();
        

        return Ok(store);
    }
}

