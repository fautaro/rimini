namespace webapi.Domain.Entities;
public class Product
{
    public long ProductId { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public decimal? Price { get; set; }

    // Claves foráneas
    public long? CategoryId { get; set; }
    public long StoreId { get; set; }

    // Otras propiedades
    public string? ProductImage { get; set; }

    public Store Store { get; set; } = null!;
    public Category? Category { get; set; }
}

