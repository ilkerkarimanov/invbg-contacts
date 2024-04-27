using Ardalis.GuardClauses;

namespace InvBG.Contacts.Backend.Domain
{
    public record Name
    {

        public string FirstName { get; init; } = string.Empty;
        public string LastName { get; init; } = string.Empty;

        private Name() { }

        public static Name Create(
            string firstName,
            string lastName
            )
        {
            Guard.Against.NullOrEmpty(firstName, nameof(FirstName), "");
            Guard.Against.StringTooShort(firstName, 1, nameof(FirstName));
            Guard.Against.StringTooLong(firstName, 20, nameof(FirstName));


            Guard.Against.NullOrEmpty(lastName, nameof(LastName), "");
            Guard.Against.StringTooShort(lastName, 1, nameof(LastName));
            Guard.Against.StringTooLong(lastName, 20, nameof(lastName));

            return new Name() { FirstName = firstName, LastName = lastName };
        }
    }
}
