using Business.Abstract;
using Business.Helper;
using DataAccess.Abstract;
using Entity.Concrete;

namespace Business.Concrete
{
    public class PortfolioManager : IPortfolioService
    {
        private readonly IPortfolioDal portfolioDal;
        public PortfolioManager(IPortfolioDal portfolioDal)
        {
            this.portfolioDal = portfolioDal;
        }

        public async Task Add(Portfolio portfolio)
        {
            await portfolioDal.AddAsync(portfolio);
        }

        public async Task Delete(string id)
        {
            var portfolio = await portfolioDal.GetAsync(x => x.Id.ToString() == id);

            SystemIOOperations.DeletePhoto("Portfolio", portfolio.PhotoUrl);

            await portfolioDal.DeleteAsync(portfolio);
        }

        public async Task<List<Portfolio>> GetAll()
        {
            var portfolios = await portfolioDal.GetAllAsync();

            return portfolios;
        }

        public async Task<Portfolio> GetDetail(string id)
        {
            var value = await portfolioDal.GetAsync(x => x.Id.ToString() == id);

            return value;
        }
    }
}
