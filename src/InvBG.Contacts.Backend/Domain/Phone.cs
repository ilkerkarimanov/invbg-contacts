using Ardalis.GuardClauses;

namespace InvBG.Contacts.Backend.Domain
{
    public record Phone
    {
        public string Value { get; init; } = string.Empty;

        private Phone() { }

        public static Phone Create(string value)
        {
            Guard.Against.NullOrEmpty(value, nameof(Value));

            return new Phone() { Value = value };
        }
    }
}
