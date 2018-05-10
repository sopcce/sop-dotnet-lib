using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Sop.Common.Tests.Serialization.Model
{
  [Serializable()]
  public class UsersLoginInfo
  {
    public int Id { get; set; }
    public string name { get; set; }


    [XmlAttribute(AttributeName = "uphone")]
    public string phone { get; set; }

    [XmlElement(ElementName = "ucity")]
    public string city { get; set; }



    public string address { get; set; }

  }
}
