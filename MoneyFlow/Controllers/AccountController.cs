using Microsoft.AspNetCore.Mvc;
using MoneyFlow.Managers;
using MoneyFlow.Models;

namespace MoneyFlow.Controllers
{
    public class AccountController(UserManager _userManager) : Controller
    {
        public IActionResult Login()
        {
            var viewModel = new LoginVM();
           
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Login(LoginVM viewModel)
        {
            if (!ModelState.IsValid) return View(viewModel);
            var found = _userManager.Login(viewModel);
            if (found.UserId == 0)
            {
                ViewBag.Message = "No matches found.";
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }


}
