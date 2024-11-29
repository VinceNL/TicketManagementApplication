using Domain.Entities;

namespace Domain.Interfaces
{
    public interface ICriteriaService
    {
        List<Category> GetCategories();
        List<Priority> GetPriorities();
        List<Product> GetProducts();
        List<string> GetStatus();
    }
}
