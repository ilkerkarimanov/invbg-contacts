using FluentValidation;
using InvBG.Contacts.Backend.Application.GetContacts;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.AspNetCore.Http.Results;

namespace InvBG.Contacts.Backend.Presentaion
{
    internal static class GetContactsEndpoint
    {
        internal static IEndpointRouteBuilder UseGetContactsEndpoint(this IEndpointRouteBuilder endpoints)
        {
            endpoints
                .MapGet(
                    "",
                    async (
                    [FromServices] IMediator mediator) =>
                    {
                        var query = new GetContactsQuery();
                        var result = await mediator.Send(query);
                        return Ok(result);
                    })
                .Produces<IReadOnlyList<GetContactQueryResult>>()
                .Produces(StatusCodes.Status400BadRequest)
                .Produces(StatusCodes.Status404NotFound);

            return endpoints;
        }
    }
}
