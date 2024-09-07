using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace webapi.Application.Store.Queries.DTOs;
public class StoreDTO
{
    public long StoreId { get; set; }
    public string? Name { get; set; }
    public string? Url { get; set; }
    public string? Instagram { get; set; }
    public string? Whatsapp { get; set; }
    public string? Address { get; set; }
    public string? ImageUrl { get; set; }
    public List<CategoryDTO>? Categories { get; set; }
}
