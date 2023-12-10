using Entity.Concrete;

namespace Business.Abstract
{
    public interface IPortfolioService
    {
        Task Add(Portfolio portfolio);
        Task<List<Portfolio>> GetAll();
        Task Delete(string id);
    }
}
