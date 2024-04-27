using InvBG.Contacts.Backend.Domain;
using InvBG.Contacts.Backend.Infrastructure;
using MediatR;

namespace InvBG.Contacts.Backend.Application.GetContacts
{
    public class GetContactsHandler (ContactsDbContext _dbContext) : IRequestHandler<GetContactsQuery, List<GetContactQueryResult>>
    {
        public Task<List<GetContactQueryResult>> Handle(GetContactsQuery request, CancellationToken cancellationToken)
        {
            var result = _dbContext.Set<Contact>()
            .Select(x => new GetContactQueryResult(
                    x.Id,
                    x.Name.FirstName,
                    x.Name.LastName,
                    new DateTime(x.DateOfBirth.Year, x.DateOfBirth.Month, x.DateOfBirth.Day),
                    x.Address.Street,
                    x.Address.ZipCode,
                    x.Address.City,
                    x.PhoneNumber.Value,
                    x.IBAN.Value
                    ))
            .ToList();

            return Task.FromResult(result);
        }
    }
}
