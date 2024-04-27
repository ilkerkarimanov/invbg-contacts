
namespace InvBG.Contacts.Backend.Application.GetContactById
{
    public record GetContactByIdQueryResult : ContactResult
    {
        public GetContactByIdQueryResult(long Id, string FirstName, string LastName, DateTime DateOfBirth, string Street, string ZipCode, string City, string PhoneNumber, string IBAN) : base(Id, FirstName, LastName, DateOfBirth, Street, ZipCode, City, PhoneNumber, IBAN)
        {
        }
    }
}
