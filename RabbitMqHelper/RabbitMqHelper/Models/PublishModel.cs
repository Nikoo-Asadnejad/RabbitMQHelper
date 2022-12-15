namespace RabbitMqHelper.Models;
public class PublishModel
{
  public string QueueTag { get; set; }
  public byte[] Body { get; set; }
  public ExchangeModel Exchange { get; set; }
  public SettingModel Setting { get; set; }

  public PublishModel(string queueTag , object body, SettingModel setting = null, ExchangeModel exchange = null ,)
  {
    QueueTag = queueTag;
    Body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(body));
    Setting = setting ?? new SettingModel();
    Exchange = exchange;
  }

}
