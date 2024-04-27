using Ardalis.GuardClauses;

namespace InvBG.Contacts.Backend.Domain
{
    public record IBAN
    {
        public string Value { get; init; } = string.Empty;

        private IBAN() { }

        public static IBAN Create(string value)
        {
            Guard.Against.NullOrEmpty(value, nameof(Value));
            Guard.Against.LengthOutOfRange(value, 20, 20, nameof(Value));

            return new IBAN() { Value = value };
        }
    }
}
