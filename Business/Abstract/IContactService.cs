using Entity.Concrete;

namespace Business.Abstract
{
    public interface IContactService
    {
        Contact Get();
        Task Update(Contact contact);
    }
}
