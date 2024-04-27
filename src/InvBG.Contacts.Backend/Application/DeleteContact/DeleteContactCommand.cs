using MediatR;

namespace InvBG.Contacts.Backend.Application.DeleteContact
{
    public record DeleteContactCommand (long ContactId) : IRequest;
}
