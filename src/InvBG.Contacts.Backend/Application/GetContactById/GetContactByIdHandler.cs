using FluentValidation;
using InvBG.Contacts.Backend.Domain;
using InvBG.Contacts.Backend.Infrastructure;
using MediatR;

namespace InvBG.Contacts.Backend.Application.GetContactById
{
    public class GetContactByIdHandler(ContactsDbContext _dbContext, IValidator<GetContactByIdQuery> _validator)
        : IRequestHandler<GetContactByIdQuery, GetContactByIdQueryResult>
    {
        public Task<GetContactByIdQueryResult> Handle(GetContactByIdQuery request, CancellationToken cancellationToken)
        {
            _validator.ValidateAndThrow(request);

            var result = _dbContext.Set<Contact>()
                .Where(x => x.Id == request.Id)
                .Select(x => new GetContactByIdQueryResult(
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
                .FirstOrDefault();

            if (result == null)
            {
                throw new InvalidOperationException("Contact cannot be found");
            }

            return Task.FromResult(result);
        }
    }
}
