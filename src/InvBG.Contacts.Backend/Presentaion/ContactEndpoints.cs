using Carter;

namespace InvBG.Contacts.Backend.Presentaion
{
    public class ContactEndpoints : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("api/contacts");

            group.UseGetContactsEndpoint();
            group.UseGetContactByIdEndpoint();
            group.UseCreateContactEndpoint();
            group.UseEditContactEndpoint();
            group.UseDeleteContactEndpoint();
        }
    }
}
