using MoneyFlow.Context;
using MoneyFlow.Entities;
using MoneyFlow.Models;

namespace MoneyFlow.Managers
{
    public class ServiceManager(AppDbContext _dbContext)
    {
        //Metodo para listar los servicio = iduser
        public List<ServiceVM> GetAll(int IdUser)
        {

            var list = _dbContext.Service
                .Where(item => item.UserId == IdUser)
                .Select(item => new ServiceVM
                {
                    ServiceId = item.ServiceId,
                    UserId = item.UserId,
                    Name = item.Name,
                    Type = item.Type,
                })
                .ToList();
            return list; 

        }


        // new service method 
        public int NewService(ServiceVM viewModel)
        {
            var entity = new Service
            {
                Name = viewModel.Name,
                Type = viewModel.Type,
                UserId = viewModel.UserId,
            };

            _dbContext.Service.Add(entity);
            var rowAfected = _dbContext.SaveChanges();
            return rowAfected;

        }
    }
}
