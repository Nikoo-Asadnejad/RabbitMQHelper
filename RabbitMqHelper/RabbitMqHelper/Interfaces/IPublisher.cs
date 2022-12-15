using RabbitMqHelper.Models;

namespace RabbitMqHelper.Interfaces;
public interface IPublisher
{
  Task<bool> SendAsync(PublishModel publishModel);
}
