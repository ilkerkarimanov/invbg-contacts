using FluentValidation;
using InvBG.Contacts.Backend.Domain;
using MediatR;

namespace InvBG.Contacts.Backend.Application.EditContact
{
    public class EditContactCommandHandler : IRequestHandler<EditContactCommand>
    {
        private readonly IContactRepository _contactRepository;
        private readonly IValidator<EditContactCommand> _validator;

        public EditContactCommandHandler(IContactRepository contactRepository, IValidator<EditContactCommand> validator)
        {
            _contactRepository = contactRepository;
            _validator = validator;

        }

        public Task Handle(EditContactCommand request, CancellationToken cancellationToken)
        {
            _validator.ValidateAndThrow(request);

            var contactId = request.Id;

            var contact = _contactRepository.Get(contactId);
            if (contact == null)
            {
                throw new InvalidOperationException("Contact cannot be found");
            }

            contact.ChangeName(Name.Create(request.FirstName, request.LastName));
            contact.ChangeDateOfBirth(DateOnly.FromDateTime(request.DateOfBirth));
            contact.ChangeAddress(Address.Create(
                request.Street,
                request.ZipCode,
                request.City));
            contact.ChangePhone(Phone.Create(request.PhoneNumber));
            contact.ChangeIBAN(IBAN.Create(request.IBAN));

            _contactRepository.Edit(contact);

            return Task.CompletedTask;
        }
    }
}
