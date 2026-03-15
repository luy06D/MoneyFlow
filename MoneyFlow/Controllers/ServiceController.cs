using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoneyFlow.Context;
using MoneyFlow.Managers;
using MoneyFlow.Models;
using System.Security.Claims;

namespace MoneyFlow.Controllers
{
    [Authorize]
    public class ServiceController(ServiceManager _serviceManager) : Controller
    {
        public IActionResult Index()
        {
            var UserId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)!.Value;
            var getAll = _serviceManager.GetAll(int.Parse(UserId));
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

            var UserId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)!.Value;
            model.UserId = int.Parse(UserId);
            var response = _serviceManager.NewService(model);
            if (response == 1) return RedirectToAction("Index");

            ViewBag.message = "Error";
            return View();
        }

        [HttpGet]
        public IActionResult UpdateService(int id) 
        {
            var model = _serviceManager.GetById(id);    
            return View(model);
        }

        [HttpPost]
        public IActionResult UpdateService(ServiceVM model)
        {
            if (!ModelState.IsValid) return View(model);

            var response = _serviceManager.UpdateService(model);
            if(response == 1) return  RedirectToAction("Index");
            ViewBag.message = "Error";

            return View(model);

        }

        public IActionResult DeleteService(int id)
        {
            var response = _serviceManager.DeleteService(id);
            return RedirectToAction("Index");
        }


    }
}    
