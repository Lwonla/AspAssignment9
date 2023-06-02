using Microsoft.AspNetCore.Mvc;
using WebApp.Helpers.Repositories;
using WebApp.Models.ViewModels;

namespace WebApp.Controllers
{
    public class ContactsController : Controller
    {
        private readonly ContactFormRepository _contactFormViewModel;

        public ContactsController(ContactFormRepository contactFormViewModel)
        {
            _contactFormViewModel = contactFormViewModel;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(ContactFormViewModel viewModel)
        {
            if(ModelState.IsValid)
            {
                await _contactFormViewModel.AddAsync(viewModel);
                return RedirectToAction(nameof(Index));
            }

            return View(viewModel);
        }
    }
}
