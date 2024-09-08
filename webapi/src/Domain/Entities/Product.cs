namespace webapi.Domain.Entities;
public class Product
{
    public long Product_id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public decimal? Price { get; set; }
    public long? Category_id { get; set; }
    public long Store_id { get; set; }
    public string? Product_Image { get; set; }
    public Store Store { get; set; } = null!;
    public Category? Category { get; set; }
}

