using System.Diagnostics.SymbolStore;

namespace RabbitMqHelper.Models;
public class SettingModel
{
  public bool Durable { get; set; }
  public bool PropertiesPersistance { get; set; }
  public bool Exclusive { get; set; }
  public bool AutoDelete { get; set; }

  /// <summary>
  /// 
  /// </summary>
  /// <param name="durable"></param>
  /// <param name="propertiesPersistance"></param>
  /// <param name="exclusive"></param>
  /// <param name="autoDelete"></param>
  public SettingModel(bool durable = true, bool propertiesPersistance = true,
                      bool exclusive = false, bool autoDelete = false)
  {
    Durable = durable;
    PropertiesPersistance = propertiesPersistance;
    Exclusive = exclusive;
    AutoDelete = autoDelete;
  }
}

