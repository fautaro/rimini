namespace webapi.Domain.Entities;
public class Store
{
    public long store_id { get; set; }

    public string? Name { get; set; }
    public string? Url { get; set; }
    public string? Instagram { get; set; }
    public string? Whatsapp { get; set; }
    public string? Address { get; set; }
    public string? ImageUrl { get; set; }
    public DateTime? created_at { get; set; }
    public string? TokenAccess { get; set; }

    // Colecciones de categorías y productos
    public ICollection<Category> Categories { get; set; } = new List<Category>();
    public ICollection<Product> Products { get; set; } = new List<Product>();
}
