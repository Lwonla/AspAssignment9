using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Helpers.Services;
using WebApp.Models.Entities;
using WebApp.Models.ViewModels;

namespace WebApp.Controllers;

public class RegisterController : Controller
{
    private readonly UserManager<UserEntity> _userManager;
    private readonly AuthenticationService _authenticationService;

    public RegisterController(UserManager<UserEntity> userManager, AuthenticationService authenticationService)
    {
        _userManager = userManager;
        _authenticationService = authenticationService;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Index(RegisterViewModel viewModel)
    {
        if (ModelState.IsValid)
        {
            if (!await _userManager.Users.AnyAsync(u => u.Email == viewModel.Email))
            {
                if (await _authenticationService.RegisterAsync(viewModel))
                    return RedirectToAction("Index", "Login");
            }
            else
            {
                ModelState.AddModelError("", "A user with that email already exists.");
            };
        }
        return View(viewModel);
    }
}
