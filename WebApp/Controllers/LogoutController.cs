using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models.Entities;

namespace WebApp.Controllers
{

    
    public class LogoutController : Controller
    {
        private readonly SignInManager<UserEntity> _signInManager;

        public LogoutController(SignInManager<UserEntity> signInManager)
        {
            _signInManager = signInManager;
        }

        public async Task<IActionResult> Index()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home"); // Redirect to home page

        }
    }
}
