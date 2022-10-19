using AutoMapper;
using Bluebank.Banco.Aplicacion.Acounts;
using Bluebank.Banco.Aplicacion.Common;
using Bluebank.Banco.Aplicacion.Customers;
using Bluebank.Banco.Aplicacion.Mapper;
using Bluebank.Banco.Infraestructure.Data;
using Bluebank.Banco.Infraestructure.Logging;
using Bluebank.Banco.Infraestructure.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Bluebank.Banco.Bootstrap
{
  public static class Injection
  {
    public static IServiceCollection Initialize(this IServiceCollection services, IConfiguration configuration)
    {
      services.AddSingleton<IConfiguration>(configuration);
      services.AddSingleton<IConnectionFactory, ConnectionFactory>();
      services.AddScoped<CustomersApplication, CustomersApplication>();
      services.AddScoped<ICustomersRepository, CustomersRepository>();
      services.AddScoped<AcountsAplicacion, AcountsAplicacion>();
      services.AddScoped<IAcountRepository, AcountRepository>();
      services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));
      // Auto Mapper Configurations
      var mappingConfig = new MapperConfiguration(mc =>
      {
        mc.AddProfile(new MappingsProfile());
      });
      IMapper mapper = mappingConfig.CreateMapper();
      services.AddSingleton(mapper);

      return services;
    }
  }
}