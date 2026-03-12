
using MoneyFlow.Context;
using MoneyFlow.Entities;
using MoneyFlow.Models;
using MoneyFlow.DTOs;
using MoneyFlow.Utilities;

namespace MoneyFlow.Managers
{
    public class UserManager(AppDbContext _dbContext)
    {
        public UserVM Login(LoginVM viewModel)
        {
            var getData = _dbContext.User
                .Where(item => item.Email == viewModel.Email &&
                item.Password == Sha256Hasher.ComputeHash(viewModel.Password)).FirstOrDefault();

            var user = new UserVM();

            if (getData != null)
            {
                user.UserId = getData.UserId;
                user.FullName = getData.FullName;
                user.Email = getData.Email;

            }

            return user;
        }

        public int NewUser(UserVM viewModel)
        {
            if (viewModel.Password != viewModel.RepeatPassword)
                throw new InvalidOperationException("The password are not the same");

            var foundUser = _dbContext.User.Any(i => i.Email == viewModel.Email);
            if (foundUser)
                throw new InvalidOperationException("The email address is already registered");

            var data = new User
            {
                UserId = viewModel.UserId,
                FullName = viewModel.FullName,
                Email = viewModel.Email,
                Password = Sha256Hasher.ComputeHash(viewModel.Password)
            };

            _dbContext.User.Add(data);
            var rowAfected = _dbContext.SaveChanges();
            return rowAfected;
        }
    }
}
