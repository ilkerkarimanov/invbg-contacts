using FluentValidation;

namespace InvBG.Contacts.Backend.Application.DeleteContact
{
    public class DeleteContactCommandValidator : AbstractValidator<DeleteContactCommand>
    {
        public DeleteContactCommandValidator()
        {
            RuleFor(x => x.ContactId).NotNull().GreaterThan(0);
        }
    }
}
