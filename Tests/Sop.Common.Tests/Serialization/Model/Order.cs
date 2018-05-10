using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Sop.Common.Tests.Serialization.Model
{
  [Serializable()]
  public class Order
  {
    public int Id { get; set; }
    [XmlAttribute(AttributeName = "Name")]
    public string Name { get; set; }

    [XmlElement(ElementName = "describe")]
    public string describe { get; set; }

    public UsersLoginInfo UsersLoginInfo { get; set; }
  }
}
