using Microsoft.AspNetCore.Mvc;
using MoneyFlow.Managers;

namespace MoneyFlow.Controllers
{
    public class TransactionController(
        TransactionManager _transactionManager,
        ServiceManager _serviceManager
        
        ) : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ServicesByType(string typeService)
        {
            //TODO : change userd
            var userId = 1;
            var result = _serviceManager.GetByType(userId, typeService);
            return Ok(result);  
        

        }
    }
}
    