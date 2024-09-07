using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace webapi.Domain.Entities;
public class Store
{
    public long StoreId { get; set; }
    public string? Name { get; set; }
    public string? Url { get; set; }
    public string? Instagram { get; set; }
    public string? Whatsapp { get; set; }
    public string? Address { get; set; }
    public string? ImageUrl { get; set; }
    public DateTime? CreatedAt { get; set; }
    public string? TokenAccess { get; set; }

    public ICollection<Product>? Products { get; set; }
    public ICollection<Category>? Categories { get; set; }
}
