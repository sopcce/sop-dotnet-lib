using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sop.Common.Img.Utility;
using System.IO;
using System.Net.Mime;
using Sop.Common.Img.Gif;

namespace Sop.Common.Tests.Img
{
  [TestClass]
  public class UnitTest1
  {
    [TestMethod]
    public void TestGif()
    {
      //E:\Item\.Net-Common-Utility\Tests\Sop.Common.Tests\Img
      //E:\Item\.Net-Common-Utility\Tests\Sop.Common.Tests\bin\Debug\src


      string file = FileUtility.GetDiskFilePath("~/src");
      if (File.Exists(file))
      {
        File.Create(file);
      }
      var imageFilePaths = new DirectoryInfo(file).GetFiles();


      String outputFilePath = file + Guid.NewGuid().ToString() + ".gif";
      AnimatedGifEncoder ae = new AnimatedGifEncoder();
      ae.Start(outputFilePath);

      ae.SetDelay(500);    // 延迟间隔
      ae.SetRepeat(0);  //-1:不循环,0:总是循环 播放   
      ae.AddFrame(MediaTypeNames.Image.FromFile(@"c:\03.png"));
      for (int i = 0, count = imageFilePaths.Length; i < count; i++)
      {
        ae.SetDelay(100);
        ae.AddFrame(MediaTypeNames.Image.FromFile(imageFilePaths[i]));
      }
      ae.Finish();


      //string outputPath = "c:\\";
      //GifDecoder gifDecoder = new GifDecoder();
      //gifDecoder.Read("c:\\test.gif");
      //for (int i = 0, count = gifDecoder.GetFrameCount(); i < count; i++)
      //{
      //    Image frame = gifDecoder.GetFrame(i);  // frame i
      //    frame.Save(outputPath + Guid.NewGuid().ToString() + ".png", ImageFormat.Png);
      //}
      ///--------------
      //Validate va = new Validate(120, 45);
      //va.Create("111.gif");

      //FileStream fs = new FileStream("222.gif", FileMode.Create);
      //va.Create(fs);
      //fs.Close();

      //Console.WriteLine("已生成，请查看Debug文件夹...");
      //Console.WriteLine("*\r\n*\r\n*\r\n*\r\n*\r\n*\r\n*\r\n");
      //Console.WriteLine("用途：网站登录验证码等。");
      //Console.Read();
    }


   [TestMethod]
    public void TestGif1()
    {
      //String[] imageFilePaths = new String[] { "C:\\01.png", "C:\\02.png" };
      //String outputFilePath = "c:\\test.gif";
      //AnimatedGifEncoder ae = new AnimatedGifEncoder();
      //ae.Start(outputFilePath);

      //ae.SetDelay(500);    // 延迟间隔
      //ae.SetRepeat(0);  //-1:不循环,0:总是循环 播放   
      //ae.AddFrame(Image.FromFile(@"c:\03.png"));
      //for (int i = 0, count = imageFilePaths.Length; i < count; i++)
      //{
      //    ae.SetDelay(100);
      //    ae.AddFrame(Image.FromFile(imageFilePaths[i]));
      //}
      //ae.Finish();


      //string outputPath = "c:\\";
      //GifDecoder gifDecoder = new GifDecoder();
      //gifDecoder.Read("c:\\test.gif");
      //for (int i = 0, count = gifDecoder.GetFrameCount(); i < count; i++)
      //{
      //    Image frame = gifDecoder.GetFrame(i);  // frame i
      //    frame.Save(outputPath + Guid.NewGuid().ToString() + ".png", ImageFormat.Png);
      //}
      ///--------------
      Validate va = new Common.Img.Gif.Validate(120, 45);
      va.Create("111.gif");

      FileStream fs = new FileStream("222.gif", FileMode.Create);
      va.Create(fs);
      fs.Close();

      Console.WriteLine("已生成，请查看Debug文件夹...");
      Console.WriteLine("*\r\n*\r\n*\r\n*\r\n*\r\n*\r\n*\r\n");
      Console.WriteLine("用途：网站登录验证码等。");
      Console.Read();
    }


  }
}
