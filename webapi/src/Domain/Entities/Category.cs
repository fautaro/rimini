using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace webapi.Domain.Entities;
public class Category
{
    public long CategoryId { get; set; }
    public long StoreId { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }

    public Store? Store { get; set; }
    public ICollection<Product>? Products { get; set; }
}
