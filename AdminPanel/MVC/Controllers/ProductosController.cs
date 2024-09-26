using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers;
public class ProductosController : Controller
{
    #region GET
    public IActionResult Index()
    {
        return View();
    }
    public IActionResult Nuevo()
    {
        return View();
    }
    public IActionResult Editar()
    {
        return View();
    }

    public IActionResult Desactivar()
    {
        return View();
    }
    #endregion

    #region POST

    #endregion
}
