using MediatR;
using Microsoft.AspNetCore.Mvc;
using MVC.Models;
using MVC.Services;
using System.Diagnostics;

namespace MVC.Controllers;

public class DashboardController : Controller
{
    private readonly IMediator _mediator;
    private readonly CurrentUserService _currentUserService;
    private readonly LoginService _loginService;

    // Constructor con inyección de dependencias
    public DashboardController(IMediator mediator, CurrentUserService currentUserService, LoginService loginService)
    {
        _mediator = mediator;
        _currentUserService = currentUserService;
        _loginService = loginService;
    }
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
