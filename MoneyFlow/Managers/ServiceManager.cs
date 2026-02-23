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


        // Obtener servicio por ID 
        public ServiceVM GetById( int id)
        {
            var entity = _dbContext.Service.Find(id);

            var model = new ServiceVM
            {
                ServiceId = id,
                Name = entity.Name,
                Type = entity.Type,
            };

            return model;

        }


        // Update service 

        public int UpdateService(ServiceVM model)
        {
            var entity = _dbContext.Service.Find(model.ServiceId);

            entity.Name = model.Name;
            entity.Type = model.Type;   

            _dbContext.Service.Update(entity);
            var affect_row = _dbContext.SaveChanges();

            return affect_row;
        }

        // Delete service 

        public int DeleteService(int id)
        {
            var entity = _dbContext.Service.Find(id);

            _dbContext.Service.Remove(entity);
            var affectRow = _dbContext.SaveChanges();
            return affectRow;
        }

        // Method for obtaining service by type


        public List<ServiceVM> GetByType(int userId , string type)
        {

            var listType = _dbContext.Service
                .Where(item => item.UserId == userId && item.Type == type)
                .Select(item => new ServiceVM
                {
                    ServiceId = item.ServiceId,
                    Name = item.Name,
                })
                .ToList();
            return listType;

        }

    }
}
