using Microsoft.AspNetCore.Mvc;
using MoneyFlow.Managers;
using MoneyFlow.Models;

namespace MoneyFlow.Controllers
{
    public class AccountController(UserManager _userManager) : Controller
    {
        public IActionResult View()
        {
            var viewModel = new LoginVM();
           
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Login()
        {
            return View();  
        }
    }
}
