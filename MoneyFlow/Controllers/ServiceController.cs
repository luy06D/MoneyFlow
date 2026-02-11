using Microsoft.AspNetCore.Mvc;
using MoneyFlow.Context;
using MoneyFlow.Managers;

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
    }
}
