using MediatR;
using Microsoft.AspNetCore.Mvc;
using MVC.Services;

namespace MVC.Controllers;
public class ProductosController : Controller
{
    private readonly IMediator _mediator;
    private readonly CurrentUserService _currentUserService;
    private readonly LoginService _loginService;

    // Constructor con inyección de dependencias
    public ProductosController(IMediator mediator, CurrentUserService currentUserService, LoginService loginService)
    {
        _mediator = mediator;
        _currentUserService = currentUserService;
        _loginService = loginService;
    }

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
