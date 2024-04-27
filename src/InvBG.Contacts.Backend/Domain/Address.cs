using Ardalis.GuardClauses;

namespace InvBG.Contacts.Backend.Domain
{
    public record Address {

        public string Street { get; init; } = string.Empty;
        public string ZipCode { get; init; } = string.Empty;
        public string City { get; init; } = string.Empty;

        private Address() { }

        public static Address Create(
            string street,
            string zipCode,
            string city)
        {
            Guard.Against.NullOrEmpty(street);
            Guard.Against.LengthOutOfRange(street, 1, 100);

            Guard.Against.NullOrEmpty(zipCode);
            Guard.Against.LengthOutOfRange(zipCode, 1, 5);

            Guard.Against.NullOrEmpty(city);
            Guard.Against.LengthOutOfRange(city, 1, 20);

            return new Address()
            {
                Street = street,
                ZipCode = zipCode,
                City = city
            };
        }
    }
}
