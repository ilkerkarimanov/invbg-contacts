using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace InvBG.Contacts.Backend.Infrastructure
{
    public class ContactsDbContext : DbContext
    {
        public const string DEFAULT_SCHEMA = "contacts";

        public ContactsDbContext(DbContextOptions<ContactsDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
