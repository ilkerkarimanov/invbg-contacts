using Ardalis.GuardClauses;

namespace InvBG.Contacts.Backend.Domain
{
    public class Contact : Entity
    {
        public Name Name { get; private set; }
        public DateOnly DateOfBirth { get; private set; }
        public Address Address { get; private set; }
        public Phone PhoneNumber { get; private set; }
        public IBAN IBAN { get; private set; }

        public void ChangeName (Name name)
        {
            Name = name;
        }

        public void ChangeDateOfBirth (DateOnly dateOfBirth)
        {
            DateOfBirth = dateOfBirth;
        }

        public void ChangeAddress (Address address)
        {
            Address = address;
        }

        public void ChangePhone (Phone phone)
        {
            PhoneNumber = phone;
        }

        public void ChangeIBAN(IBAN iban)
        {
            IBAN = iban;
        }

        public static Contact Create(
            Name name,
            DateOnly dateOfBirth,
            Address address,
            Phone phoneNumber,
            IBAN iban)
        {
            return new Contact()
            {
                Id = 0,
                Name = name,
                DateOfBirth = dateOfBirth,
                Address = address,
                PhoneNumber = phoneNumber,
                IBAN = iban
            };
        }
    }
}
