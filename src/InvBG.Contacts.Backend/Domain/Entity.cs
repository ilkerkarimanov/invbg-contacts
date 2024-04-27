namespace InvBG.Contacts.Backend.Domain
{
    public abstract class Entity
    {
        long _Id;
        public virtual long Id
        {
            get
            {
                return _Id;
            }
            protected set
            {
                _Id = value;
            }
        }
    }
}
