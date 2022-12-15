namespace RabbitMqHelper.Models;
public class PublishModel
{
  public string QueueTag { get; set; }
  public byte[] Body { get; set; }
  public ExchangeModel Exchange { get; set; }
  public PublishSettingModel Setting { get; set; }

  public PublishModel(string queueTag , object body, PublishSettingModel setting = null, ExchangeModel exchange = null )
  {
    QueueTag = queueTag;
    Body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(body));
    Setting = setting ?? new PublishSettingModel();
    Exchange = exchange;
  }

}
