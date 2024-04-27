using MediatR;

namespace InvBG.Contacts.Backend.Application.EditContact
{
    public record EditContactCommand(
        long Id,
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
