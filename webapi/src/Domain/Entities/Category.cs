namespace webapi.Domain.Entities;
public class Category
{
    public long Category_id { get; set; }
    public long Store_id { get; set; }  // No nullable porque siempre debería haber una tienda asociada

    public string? Name { get; set; }  // Nullable porque el nombre podría no estar especificado
    public string? Description { get; set; }  // Nullable porque la descripción podría no estar especificada

    public Store Store { get; set; } = null!;  // No nullable porque StoreId no es nullable y siempre debería haber una tienda
    public ICollection<Product> Products { get; set; } = new List<Product>();  // No nullable porque siempre queremos al menos una lista vacía
}

