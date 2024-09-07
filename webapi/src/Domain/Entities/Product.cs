using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace webapi.Domain.Entities;
public class Product
{
    public long ProductId { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public decimal? Price { get; set; }
    public long? CategoryId { get; set; }
    public long StoreId { get; set; }
    public string? ProductImage { get; set; }

    public Store? Store { get; set; }
    public Category? Category { get; set; }
}
