using Entity.Concrete;

namespace Business.Abstract
{
    public interface ICategoryService
    {
        Task<List<Category>> GetAll();
        Task Add(Category category);
        Task Delete(string id);
        Task Update(Category category);
        Task<Category> GetById(string id);
    }
}
