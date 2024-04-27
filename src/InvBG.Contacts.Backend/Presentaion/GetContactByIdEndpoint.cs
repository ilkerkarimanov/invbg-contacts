using InvBG.Contacts.Backend.Application.GetContactById;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.AspNetCore.Http.Results;

namespace InvBG.Contacts.Backend.Presentaion
{
    internal static class GetContactByIdEndpoint
    {
        internal static IEndpointRouteBuilder UseGetContactByIdEndpoint(this IEndpointRouteBuilder endpoints)
        {
            endpoints
                .MapGet(
                    "{id}",
                    async ([FromQuery] long id,
                    [FromServices] IMediator mediator) =>
                    {
                        var query = new GetContactByIdQuery(id);
                        var result = await mediator.Send(query);
                        return Ok(result);
                    })
                .Produces<GetContactByIdQueryResult>()
                .Produces(StatusCodes.Status400BadRequest)
                .Produces(StatusCodes.Status404NotFound);

            return endpoints;
        }
    }
}
