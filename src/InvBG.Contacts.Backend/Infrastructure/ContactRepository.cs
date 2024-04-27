using InvBG.Contacts.Backend.Domain;
using Microsoft.EntityFrameworkCore;

namespace InvBG.Contacts.Backend.Infrastructure
{
    public class ContactRepository : IContactRepository
    {
        private ContactsDbContext _dbContext;

        public ContactRepository(ContactsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Contact contact)
        {
            if (contact.Id != 0)
            {
                throw new InvalidOperationException("Contact cannot be added due to invalid identificator.");
            }

            _dbContext.Set<Contact>().Add(contact);
            _dbContext.SaveChanges();
        }

        public void Delete(long id)
        {
            if (id == 0)
            {
                throw new InvalidOperationException("Contact cannot be deleted due to invalid identificator.");
            }

            _dbContext.Set<Contact>().Where(c => c.Id == id).ExecuteDelete();
        }

        public void Edit(Contact contact)
        {
            if (contact.Id == 0)
            {
                throw new InvalidOperationException("Contact cannot be deleted due to invalid identificator.");
            }

            _dbContext.Set<Contact>().Update(contact);
            _dbContext.SaveChanges();
        }

        public Contact Get(long id)
        {
            return _dbContext.Set<Contact>().FirstOrDefault(item => item.Id == id);
        }
    }
}
