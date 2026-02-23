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
    }
}
    