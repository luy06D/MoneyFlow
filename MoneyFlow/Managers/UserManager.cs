
using MoneyFlow.Context;
using MoneyFlow.Entities;
using MoneyFlow.Models;
using MoneyFlow.DTOs;

namespace MoneyFlow.Managers
{
    public class UserManager(AppDbContext _dbContext)
    {
        public UserVM Login(LoginVM viewModel)
        {
            var getData = _dbContext.User
                .Where(item => item.Email == viewModel.Email && 
                item.Password == item.Password).FirstOrDefault();

            var user = new UserVM();

            if(user != null)
            {
                user.UserId = getData.UserId;
                user.FullName = getData.FullName;
                user.Email = getData.Email; 

            }

            return user; 
        }
    }
}
