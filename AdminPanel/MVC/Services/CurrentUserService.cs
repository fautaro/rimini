namespace MVC.Services;

public class CurrentUserService
{
    // Propiedades públicas para acceder a la información del usuario actual
    public string? Role { get; set; }
    public int StoreId { get; set; }
    public string? StoreName { get; set; }
    public string? UserName { get; set; }

    public CurrentUserService(string role, int storeId, string storeName, string userName)
    {
        Role = role;
        StoreId = storeId;
        StoreName = storeName;
        UserName = userName;
    }

    public CurrentUserService()
    {
    }
}

