
using MoneyFlow.Context;
using MoneyFlow.Entities;
using MoneyFlow.Models;
using MoneyFlow.DTOs;


namespace MoneyFlow.Managers
{
    public class TransactionManager(AppDbContext _dbContext)
    {

        public int NewTransaction(TransactionDTO modelDto)
        {
            var entity = new Transaction
            {
                ServiceId = modelDto.ServiceId,
                UserId = modelDto.UserId,
                Comment = modelDto.Comment,
                Date = modelDto.Date,
                TotalAmount = modelDto.TotalAmount,
            };

            _dbContext.Transaction.Add(entity);
            var rowAfected = _dbContext.SaveChanges();
            return rowAfected;
            
        }

        public List<HistoryDTO> GetAllHistory(DateOnly startDate , DateOnly endDate, int userId)
        {
            var HistoryList = _dbContext.Transaction
                .Where(item => item.UserId == userId &&
                item.Date >= startDate && item.Date <= endDate)
                .Select(item => new HistoryDTO
                {
                    Date = item.Date.ToString("dd/MM/yyyy"),
                    Moth = item.Date.ToString("MMMM"),
                    TypeService = item.Service.Name,
                    TotalAmount = item.TotalAmount.ToString()
                })
                .ToList();

            return HistoryList;

        }
    }
}
