using MediatR;
using Microsoft.AspNetCore.Mvc;
using MVC.Services;

namespace MVC.Controllers;

public class CategoriasController : Controller
{
    private readonly IMediator _mediator;
    private readonly CurrentUserService _currentUserService;
    private readonly LoginService _loginService;

    // Constructor con inyección de dependencias
    public CategoriasController(IMediator mediator, CurrentUserService currentUserService, LoginService loginService)
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
    // Métodos POST que usarán el Mediator para la lógica de negocio.
    #endregion
}

