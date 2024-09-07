using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace webapi.Application.Store.Queries.DTOs;
public class CategoryDTO
{
    public long CategoryId { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public List<ProductDTO>? Products { get; set; }
}
