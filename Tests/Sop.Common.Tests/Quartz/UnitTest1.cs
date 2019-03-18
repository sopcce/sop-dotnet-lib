using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sop.Common.Quartz;

namespace Sop.Common.Tests.Quartz
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //[秒] [分] [小时] [日] [月] [周] [年]
            //实例化表达式类，把字符串转成一个对象
            CronExpression expression = new CronExpression("0 15 10 * * ? 2012");

            while (true)
            {
                DateTimeOffset utcNow = DateTime.UtcNow;
                Console.WriteLine("UtcNow - " + utcNow);

                //Console.WriteLine("GetFinalFireTime - " + expression.GetFinalFireTime());这个方法没有实现
                //得到给定时间下一个无效的时间
                Console.WriteLine("GetNextInvalidTimeAfter - " + expression.GetNextInvalidTimeAfter(utcNow));
                //得到给定时间的下一个有效的时间
                Console.WriteLine("GetNextValidTimeAfter - " + expression.GetNextValidTimeAfter(utcNow));
                //得到给定时间下一个符合表达式的时间
                Console.WriteLine("GetTimeAfter - " + expression.GetTimeAfter(utcNow));
                //Console.WriteLine("GetTimeBefore - " + expression.GetTimeBefore(utcNow));这个方法没有实现
                //给定时间是否符合表达式
                Console.WriteLine("IsSatisfiedBy - " + expression.IsSatisfiedBy(new DateTimeOffset(2012, 4, 6, 2, 15, 0, TimeSpan.Zero)));
                Console.WriteLine(expression.TimeZone);
                Console.WriteLine("------------------------------------");
                Console.WriteLine(expression.GetExpressionSummary());
                Console.Read();
            }


        }
    }
}
