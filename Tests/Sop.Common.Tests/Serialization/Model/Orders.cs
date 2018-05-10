using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Xml.Serialization;

namespace Sop.Common.Tests.Serialization.Model
{
  
  [Serializable()]
  [XmlRoot("Orders")]
  public class Orders
  {
    public int Id { get; set; }

    public Order Order { get; set; }

    [XmlAttribute(AttributeName = "OrdersName")]
    public string Name { get; set; }

    [XmlElement(ElementName = "Ordersdescribe")]
    public string describe { get; set; }

  }
}
