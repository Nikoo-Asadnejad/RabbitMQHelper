using Microsoft.Extensions.Configuration;
using RabbitMQ.Client.Events;
using RabbitMqHelper.Interfaces;
using RabbitMqHelper.Models;
using System;

namespace RabbitMqHelper.Services;
public class Consumer : IConsumer
{
  private readonly IConnectionFactory _rabbitConnectionFactory;
  private readonly IConfiguration _configuration;
  public Consumer(IConfiguration configuration)
  {
    _configuration = configuration;
    _rabbitConnectionFactory = new ConnectionFactory()
    {
      HostName = _configuration["RabbitMQ:Connection"],
      DispatchConsumersAsync = true
    };
  }
  public async Task<bool> ReceiveAsync<T>(ConsumeModel<T> consumeModel)
  {

    IConnection connection = _rabbitConnectionFactory.CreateConnection();
    IModel channel = connection.CreateModel();

    channel.QueueDeclare(queue: consumeModel.QueueTag,
                        durable: consumeModel.Setting.Durable,
                        exclusive: consumeModel.Setting.Exclusive,
                        autoDelete: consumeModel.Setting.AutoDelete);

    channel.BasicQos(prefetchSize: consumeModel.Setting.PreFetchSize,
                     prefetchCount: consumeModel.Setting.PreFetchCount,
                     global: consumeModel.Setting.Global);

    AsyncEventingBasicConsumer consumer = new(channel);

    consumer.Received += async (sender, ea) =>
    {
      byte[] arrayBody = ea.Body.ToArray();
      string body = Encoding.UTF8.GetString(arrayBody);
      T actionInput = JsonConvert.DeserializeObject<T>(body);

      var actionResult = Task.Run(() => consumeModel.Action(actionInput));
      bool isActionSuccessfull = await actionResult;
      var channel = ((AsyncEventingBasicConsumer)sender).Model;

      if (isActionSuccessfull)
        channel.BasicAck(deliveryTag: ea.DeliveryTag,
                         multiple: consumeModel.Setting.Multiple);
      else
        channel.BasicNack(deliveryTag: ea.DeliveryTag,
                         multiple: consumeModel.Setting.Multiple,
                         requeue: consumeModel.Setting.ReQueue);
    };

    channel.BasicConsume(queue: consumeModel.QueueTag,
                         autoAck: consumeModel.Setting.AutoAck,
                         consumer: consumer);

    return true;

  }
}
