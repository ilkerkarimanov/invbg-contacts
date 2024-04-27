using FluentValidation;

namespace InvBG.Contacts.Backend.Application.GetContactById
{
    public class GetContactByIdQueryValidator : AbstractValidator<GetContactByIdQuery>
    {
        public GetContactByIdQueryValidator()
        {
            RuleFor(query => query.Id).GreaterThan(0);
        }
    }
}
