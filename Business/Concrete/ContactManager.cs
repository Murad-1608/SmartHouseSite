using Business.Abstract;
using DataAccess.Abstract;
using Entity.Concrete;

namespace Business.Concrete
{
    public class ContactManager : IContactService
    {
        private readonly IContactDal contactDal;
        public ContactManager(IContactDal contactDal)
        {
            this.contactDal = contactDal;
        }

        public Contact Get()
        {
            var contact = contactDal.GetAllAsync().Result.Last();

            return contact;
        }

        public async Task Update(Contact contact)
        {
            await contactDal.UpdateAsync(contact);
        }
    }
}
