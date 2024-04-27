using MediatR;

namespace InvBG.Contacts.Backend.Application.GetContactById
{
    public record GetContactByIdQuery(long Id) : IRequest<GetContactByIdQueryResult>;
}
