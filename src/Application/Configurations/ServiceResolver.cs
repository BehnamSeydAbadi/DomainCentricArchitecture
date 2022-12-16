using MediatR.Extensions.FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using MediatR;

namespace Application.Configurations
{
    public static class ServiceResolver
    {
        public static void ResolveApplicationServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddMediatR(Assembly.GetExecutingAssembly());
            serviceCollection.AddFluentValidation(new[] { Assembly.GetExecutingAssembly() });
        }
    }
}
