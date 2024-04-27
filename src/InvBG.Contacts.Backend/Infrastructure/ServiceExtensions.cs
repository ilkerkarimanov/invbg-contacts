using InvBG.Contacts.Backend.Domain;
using Microsoft.EntityFrameworkCore;

namespace InvBG.Contacts.Backend.Infrastructure
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddContactsStore(
            this IServiceCollection services,
            IConfiguration configuration
            )
        {
            services
            .AddDbContext<ContactsDbContext>(
                options => options.UseSqlServer(configuration.GetConnectionString("ContactsDB")));

            services.AddTransient<ContactsDbInitialiser>();
            services.AddScoped<IContactRepository, ContactRepository>();

            return services;
        }

        public static IApplicationBuilder ConfigureWarehouse(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();

            var initialiser = scope.ServiceProvider.GetRequiredService<ContactsDbInitialiser>();

            initialiser.Initialise();

            initialiser.Seed();

            return app;
        }
    }
}
