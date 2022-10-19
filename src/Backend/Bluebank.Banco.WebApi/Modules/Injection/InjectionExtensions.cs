using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace Bluebank.Banco.WebApi.Modules.Injection
{
    public static class InjectionExtensions
    {
        public static IServiceCollection AddInjection(this IServiceCollection services, IConfiguration configuration)
        {
            Bluebank.Banco.Bootstrap.Injection.Initialize(services, configuration);

            return services;
        }
    }
}
