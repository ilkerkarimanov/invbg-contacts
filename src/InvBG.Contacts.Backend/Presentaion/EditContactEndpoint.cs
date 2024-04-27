using InvBG.Contacts.Backend.Application.EditContact;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.AspNetCore.Http.Results;

namespace InvBG.Contacts.Backend.Presentaion
{
    internal static class EditContactEndpoint
    {
        internal static IEndpointRouteBuilder UseEditContactEndpoint(this IEndpointRouteBuilder endpoints)
        {
            endpoints
                .MapPut(
                    "",
                    async ([FromBody] EditContactCommand command,
                    [FromServices] IMediator mediator) =>
                    {
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
