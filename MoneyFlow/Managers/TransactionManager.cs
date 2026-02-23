
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
    }
}
