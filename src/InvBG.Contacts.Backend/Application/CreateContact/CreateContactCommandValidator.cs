using FluentValidation;

namespace InvBG.Contacts.Backend.Application.CreateContact
{
    public class CreateContactCommandValidator : AbstractValidator<CreateContactCommand>
    {
        public CreateContactCommandValidator()
        {
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
