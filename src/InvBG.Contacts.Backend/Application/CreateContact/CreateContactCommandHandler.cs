using FluentValidation;
using InvBG.Contacts.Backend.Domain;
using MediatR;

namespace InvBG.Contacts.Backend.Application.CreateContact
{
    public class CreateContactCommandHandler : IRequestHandler<CreateContactCommand>
    {
        private readonly IContactRepository _contactRepository;
        private readonly IValidator<CreateContactCommand> _validator;

        public CreateContactCommandHandler(IContactRepository contactRepository, IValidator<CreateContactCommand> validator)
        {
            _contactRepository = contactRepository;
            _validator = validator;
        }

        public Task Handle(CreateContactCommand request, CancellationToken cancellationToken)
        {
            _validator.ValidateAndThrow(request);

            var contact = Contact.Create(
                Name.Create(request.FirstName, request.LastName),
                DateOnly.FromDateTime(request.DateOfBirth),
                Address.Create(
                    request.Street,
                    request.ZipCode,
                    request.City),
                Phone.Create(request.PhoneNumber),
                IBAN.Create(request.IBAN)
                );

            _contactRepository.Add(contact);

            return Task.CompletedTask;
        }
    }
}
