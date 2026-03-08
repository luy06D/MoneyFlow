using Microsoft.AspNetCore.Mvc;
using MoneyFlow.DTOs;
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

        [HttpPost]
        public IActionResult NewTransaction([FromBody] TransactionDTO modelDto)
        {
            modelDto.UserId = 1;

            var response = _transactionManager.NewTransaction(modelDto);

            return Ok(response);

        }

        public IActionResult History()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetHistory(DateOnly startDate, DateOnly endDate  )
        {
            var userId = 1;
            var result  = _transactionManager.GetAllHistory(startDate, endDate, userId); 
            return Ok(new { data = result});
        }
    }
}
    