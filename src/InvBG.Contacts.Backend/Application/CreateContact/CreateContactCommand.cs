using MediatR;

namespace InvBG.Contacts.Backend.Application.CreateContact
{
    public record CreateContactCommand (
        string FirstName,
        string LastName,
        DateTime DateOfBirth,
        string Street,
        string ZipCode,
        string City,
        string PhoneNumber,
        string IBAN
        ) : IRequest;
}
