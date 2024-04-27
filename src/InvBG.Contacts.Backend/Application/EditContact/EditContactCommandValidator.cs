using FluentValidation;

namespace InvBG.Contacts.Backend.Application.EditContact
{
    public class EditContactCommandValidator : AbstractValidator<EditContactCommand>
    {
        public EditContactCommandValidator()
        {
            RuleFor(x => x.Id).NotNull().Must(x => x != 0);
            RuleFor(x => x.FirstName).NotEmpty().Length(0, 20);
            RuleFor(x => x.LastName).NotEmpty().Length(0, 20);
            RuleFor(x => x.DateOfBirth).NotNull().SetValidator(new DateOfBirthValidator());
            RuleFor(x => x.Street).NotEmpty().Length(1, 100);
            RuleFor(x => x.City).NotEmpty().Length(1, 20);
            RuleFor(x => x.ZipCode).NotEmpty().Length(1, 5);
            RuleFor(x => x.PhoneNumber).NotEmpty().Length(13, 13);
            RuleFor(x => x.IBAN).NotEmpty().Length(20, 20);
        }
    }
}
