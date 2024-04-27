using InvBG.Contacts.Backend.Application.CreateContact;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.AspNetCore.Http.Results;

namespace InvBG.Contacts.Backend.Presentaion
{
    internal static class CreateContactEndpoint
    {
        internal static IEndpointRouteBuilder UseCreateContactEndpoint(this IEndpointRouteBuilder endpoints)
        {
            endpoints
                .MapPost(
                    "",
                    async ([FromBody] CreateContactCommand command,
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
