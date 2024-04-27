using MediatR;

namespace InvBG.Contacts.Backend.Application.GetContacts
{

    public record GetContactsQuery() : IRequest<List<GetContactQueryResult>>
    {
    }
}
