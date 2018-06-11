using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sop.Common.Serialization;
using Sop.Common.Tests.Serialization.Model;

namespace Sop.Common.Tests.Serialization
{
  [TestClass]
  public class XmlTest
  {
    [TestMethod]
    public void ToXml_Model()
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

    [TestMethod]
    public void ToXml_List()
    {

      var list = new List<Orders>()
      {
        new Orders()
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

        },
        new Orders()
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

        }
      };
      var xml = list.ToXml();

      Assert.IsNotNull(xml);


    }


    [TestMethod]
    public void ToModel_Model()
    {
      string orders = @"<?xml version=""1.0"" encoding =""utf -16"" ?>
<Orders xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" 
xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" OrdersName = ""Orders"" >
  <Id>110</Id>
  <Order Name=""Orders"" >
    <Id>110111</Id>
    <describe>2018/6/11</describe>
    <UsersLoginInfo uphone=""11222222"" >
      <Id>110112000</Id>
      <name>guojiaqiu</name>
      <ucity>2018/6/11</ucity>
    </UsersLoginInfo>
  </Order>
  <Ordersdescribe>2018/6/11</Ordersdescribe>
</Orders>";
      var xml = orders.ToModel<Orders>();

      Assert.IsNotNull(xml);

      Assert.AreEqual(xml.Id, 110);


    }
    [TestMethod]
    public void ToModel_List()
    {
      string orders = @"<?xml version=""1.0"" encoding =""utf-16"" ?>
<ArrayOfOrders xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
  <Orders OrdersName=""Orders"">
    <Id>110</Id>
    <Order Name=""Orders"">
      <Id>110111</Id>
      <describe>2018/6/11</describe>
      <UsersLoginInfo uphone=""11222222"">
        <Id>110112000</Id>
        <name>guojiaqiu</name>
        <ucity>2018/6/11</ucity>
      </UsersLoginInfo>
    </Order>
    <Ordersdescribe>2018/6/11</Ordersdescribe>
  </Orders>
  <Orders OrdersName=""Orders"">
    <Id>110</Id>
    <Order Name=""Orders"">
      <Id>110111</Id>
      <describe>2018/6/11</describe>
      <UsersLoginInfo uphone=""11222222"">
        <Id>110112000</Id>
        <name>guojiaqiu</name>
        <ucity>2018/6/11</ucity>
      </UsersLoginInfo>
    </Order>
    <Ordersdescribe>2018/6/11</Ordersdescribe>
  </Orders>
</ArrayOfOrders>";
      var xml = orders.ToModel<List<Orders>>();

      Assert.IsNotNull(xml);




    }
  }
}
