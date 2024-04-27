using InvBG.Contacts.Backend.Application.DeleteContact;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.AspNetCore.Http.Results;

namespace InvBG.Contacts.Backend.Presentaion
{
    internal static class DeleteContactEndpoint
    {
        internal static IEndpointRouteBuilder UseDeleteContactEndpoint(this IEndpointRouteBuilder endpoints)
        {
            endpoints
                .MapDelete(
                    "",
                    async ([FromQuery] long contactId,
                    [FromServices] IMediator mediator) =>
                    {
                        var command = new DeleteContactCommand(contactId);
                        await mediator.Send(command);
                        return Ok();
                    })
                .Produces(StatusCodes.Status200OK)
                .Produces(StatusCodes.Status400BadRequest)
                .Produces(StatusCodes.Status404NotFound);

            return endpoints;
        }
    }
}
