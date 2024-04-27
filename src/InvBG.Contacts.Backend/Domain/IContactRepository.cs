namespace InvBG.Contacts.Backend.Domain
{
    public interface IContactRepository
    {
        Contact Get(long id);
        void Add(Contact contact);
        void Edit(Contact contact);
        void Delete(long id);
    }
}
