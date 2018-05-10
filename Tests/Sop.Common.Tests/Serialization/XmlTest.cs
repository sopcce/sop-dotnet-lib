using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sop.Common.Serialization;
using Sop.Common.Tests.Serialization.Model;

namespace Sop.Common.Tests.Serialization
{
  [TestClass]
  public class XmlTest
  {
    [TestMethod]
    public void TestToXml()
    {
      var orders = new Orders()
      {
        Id = 110,
        Name = "Orders",
        describe = DateTime.Now.ToShortDateString(),
        Order = new Order()
        {
          Id = 110111,
          Name = "Orders",
          describe = DateTime.Now.ToShortDateString(),
          UsersLoginInfo = new UsersLoginInfo()
          {
            Id = 110112000,
            name = "guojiaqiu",
            phone = "11222222",
            city = DateTime.Now.ToShortDateString(),
          }
        }

      };
      var xml = orders.ToXml();

      Assert.IsNotNull(xml);


    }

  }
}
