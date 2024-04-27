using InvBG.Contacts.Backend.Domain;
using Microsoft.EntityFrameworkCore;

namespace InvBG.Contacts.Backend.Infrastructure
{
    public class ContactsDbInitialiser
    {
        private readonly ILogger<ContactsDbInitialiser> _logger;
        private readonly ContactsDbContext _context;

        public ContactsDbInitialiser(
            ILogger<ContactsDbInitialiser> logger,
            ContactsDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public void Initialise()
        {
            try
            {
                _context.Database.Migrate();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while initialising the database.");
                throw;
            }
        }

        public void Seed()
        {
            try
            {
                TrySeed();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while seeding the database.");
                throw;
            }
        }

        public void TrySeed()
        {
            if (!_context.Set<Contact>().Any())
            {
                _context.Set<Contact>().Add(Contact.Create(
                    Name.Create("Ilker", "Karimanov"),
                    new DateOnly(1989, 4, 18),
                    Address.Create("T.Kableshkov 19", "1000", "Byala Slatina"),
                    Phone.Create("+359888123456"),
                    IBAN.Create("11112222333344445555")
                    ));

                _context.SaveChanges();
            }
        }
    }
}
