using FluentValidation;

namespace InvBG.Contacts.Backend.Application
{
    public class DateOfBirthValidator : AbstractValidator<DateTime>
    {
        public DateOfBirthValidator()
        {
            RuleFor(x => x).NotNull().Must(BeAValidBirthDate);
        }

        private bool BeAValidBirthDate(DateTime val)
        {
            var target = DateOnly.FromDateTime(val);
            var minDate = DateOnly.FromDateTime(new DateTime(1900, 1, 1));
            var maxDate = DateOnly.FromDateTime(DateTime.UtcNow);
            return target > minDate && target < maxDate;
        }
    }
}
