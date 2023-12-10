using Business.Abstract;
using DataAccess.Abstract;
using Entity.Concrete;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal categoryDal;
        public CategoryManager(ICategoryDal categoryDal)
        {
            this.categoryDal = categoryDal;
        }

        public async Task Add(Category category)
        {
            await categoryDal.AddAsync(category);
        }

        public async Task Delete(string id)
        {
            var category = await categoryDal.GetAsync(x => x.Id.ToString() == id);

            await categoryDal.DeleteAsync(category);
        }

        public async Task<List<Category>> GetAll()
        {
            var categories = await categoryDal.GetAllAsync();

            return categories;
        }

        public async Task<Category> GetById(string id)
        {
            var category = await categoryDal.GetAsync(x => x.Id.ToString() == id);

            return category;
        }

        
        public async Task Update(Category category)
        {
            await categoryDal.UpdateAsync(category);
        }
    }
}
