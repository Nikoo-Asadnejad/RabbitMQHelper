using RabbitMqHelper.Models;

namespace RabbitMqHelper.Interfaces;
public interface IConsumer
{
  Task<bool> ReceiveAsync<T>(ConsumeModel<T> consumeModel);
}

