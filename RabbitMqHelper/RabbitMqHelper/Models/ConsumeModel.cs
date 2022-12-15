
using System;

namespace RabbitMqHelper.Models;
public class ConsumeModel<T>
{
  public Func<T, bool> Action { get; set; }
  public string QueueTag { get; set; }
  public ConsumeSettingModel Setting { get; set; }

  public ConsumeModel(string queueTag,Func<T, bool> action, ConsumeSettingModel setting = null)
  {
    Action = action;
    QueueTag = queueTag;
    Setting = setting ?? new ConsumeSettingModel();
  }
}
