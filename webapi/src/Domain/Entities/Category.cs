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
