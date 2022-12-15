using RabbitMqHelper.Enums;
namespace RabbitMqHelper.Models;
public class ExchangeModel
{
  public string Name { get; set; }
  public RabbbitMqExchangeType Type { get; set; }
  public string RoutingKey { get; set; }

  public ExchangeModel(string exchangeName,
                       RabbbitMqExchangeType exchangeType,
                       string exchangeRoutingKey)
  {
    Name = exchangeName;
    Type = exchangeType;
    RoutingKey = exchangeRoutingKey;
  }
}

