using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoneyFlow.DTOs;
using MoneyFlow.Managers;
using System.Security.Claims;

namespace MoneyFlow.Controllers
{
    [Authorize]
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
            var UserId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)!.Value;
            var userId = int.Parse(UserId);
            var result = _serviceManager.GetByType(userId, typeService);
            return Ok(result);  
        

        }

        [HttpPost]
        public IActionResult NewTransaction([FromBody] TransactionDTO modelDto)
        {
            var UserId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)!.Value;
            modelDto.UserId = int.Parse(UserId);

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
            var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)!.Value;
            var result  = _transactionManager.GetAllHistory(startDate, endDate, int.Parse(userId)); 
            return Ok(new { data = result});
        }
    }
}
    