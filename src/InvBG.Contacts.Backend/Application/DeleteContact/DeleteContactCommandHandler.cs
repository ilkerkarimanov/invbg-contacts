using FluentValidation;
using InvBG.Contacts.Backend.Domain;
using MediatR;

namespace InvBG.Contacts.Backend.Application.DeleteContact
{
    public class DeleteContactCommandHandler : IRequestHandler<DeleteContactCommand>
    {
        private readonly IContactRepository _contactRepository;
        private readonly IValidator<DeleteContactCommand> _validator;
        public DeleteContactCommandHandler(IContactRepository contactRepository,
            IValidator<DeleteContactCommand> validator)
        {
            _contactRepository = contactRepository;
            _validator = validator;
        }

        public Task Handle(DeleteContactCommand request, CancellationToken cancellationToken)
        {
            _validator.ValidateAndThrow(request);

            _contactRepository.Delete(request.ContactId);

            return Task.CompletedTask;
        }
    }
}
