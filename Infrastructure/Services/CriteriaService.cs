using Domain.Entities;
using Domain.Interfaces;
using Domain.Repositories;

namespace Infrastructure.Services
{
    public class CriteriaService(IUnitOfWork unitOfWork) : ICriteriaService
    {
        public List<Category> GetCategories()
        {
            return unitOfWork.Repository<Category>().ListAll();
        }

        public List<Priority> GetPriorities()
        {
            return unitOfWork.Repository<Priority>().ListAll();
        }

        public List<Product> GetProducts()
        {
            return unitOfWork.Repository<Product>().ListAll();
        }

        public List<string> GetStatus()
        {
            return ["NEW", "OPEN", "CLOSED"];
        }
    }
}
