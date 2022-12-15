using Microsoft.Extensions.DependencyInjection;
using RabbitMqHelper.Interfaces;
using RabbitMqHelper.Services;
namespace RabbitMqHelper.Configurations;

public static class RabbitMqHelperConfigurator
{
  public static void InjectServices(IServiceCollection service)
  {
    service.AddTransient<IPublisher, Publisher>();
    service.AddTransient<IConsumer, Consumer>();
  }

}
