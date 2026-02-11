using MoneyFlow.Context;
using MoneyFlow.Entities;

namespace MoneyFlow.Managers
{
    public class ServiceManager(AppDbContext _dbContext)
    {
        public List<Service> GetAll(int IdUser)
        {

            var list = _dbContext.Service.Where(item => item.UserId == IdUser).ToList();
            return list; 

        }
    }
}
