using Microsoft.AspNetCore.Mvc;
using MoneyFlow.Context;
using MoneyFlow.Managers;
using MoneyFlow.Models;

namespace MoneyFlow.Controllers
{
    public class ServiceController(ServiceManager _serviceManager) : Controller
    {
        public IActionResult Index()
        {
            //TODO : cambiar el USERID 

            var getAll = _serviceManager.GetAll(1);
            return View(getAll);
        }

        [HttpGet]
        public IActionResult NewServices()
        {
            return View();
        }

        [HttpPost]
        public IActionResult NewServices(ServiceVM model)
        {

            if (!ModelState.IsValid) return View(model);
            // TODO: change UserId
            model.UserId = 1;
            var response = _serviceManager.NewService(model); 
            if (response == 1) return RedirectToAction("Index");

            ViewBag.message = "Error";
            return View();
        }

    }
}    
