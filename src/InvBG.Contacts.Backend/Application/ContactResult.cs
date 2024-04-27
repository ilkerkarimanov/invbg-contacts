namespace InvBG.Contacts.Backend.Application
{
    public record ContactResult (
        long Id,
        string FirstName,
        string LastName,
        DateTime DateOfBirth,
        string Street,
        string ZipCode,
        string City,
        string PhoneNumber,
        string IBAN);
}
