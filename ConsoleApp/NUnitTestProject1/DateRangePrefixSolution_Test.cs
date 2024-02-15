using ConsoleApp.practice;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Test
{
	[TestFixture]
    public class DateRangePrefixSolution_Test
	{
        private static DateRangePrefixSolution sol = new DateRangePrefixSolution();

        private static void testing(DateTime start, DateTime end, List<string> ans)
        {
            Assert.AreEqual(sol.date_range_prefix(start, end), ans);
        }

        [Test]
        public static void test1()
        {
            testing(new DateTime(2021, 1, 1), new DateTime(2021, 12, 31), new List<string> { "2021" });
            testing(new DateTime(2021, 1, 1), new DateTime(2022, 1, 1), new List<string> { "2021", "2022/01/01" });
            testing(new DateTime(2021, 1, 1), new DateTime(2021, 1, 31), new List<string> { "2021/01" });
            testing(new DateTime(2021, 1, 1), new DateTime(2021, 3, 1), new List<string> { "2021/01", "2021/02", "2021/03/01" });
            testing(new DateTime(2021, 2, 1), new DateTime(2021, 2, 28), new List<string> { "2021/02" });
            testing(new DateTime(2020, 2, 1), new DateTime(2020, 2, 28), DaysBetween(new DateTime(2020, 2, 1), new DateTime(2020, 2, 28)).ToList());
            testing(new DateTime(2021, 11, 30), new DateTime(2023, 1, 1), new List<string> { "2021/11/30", "2021/12", "2022", "2023/01/01" });
            testing(new DateTime(2021, 1, 5), new DateTime(2021, 1, 7), new List<string> { "2021/01/05", "2021/01/06", "2021/01/07" });
        }

        private static IEnumerable<string> DaysBetween(DateTime s, DateTime e)
        {
            DateTime c = s;
            while (c <= e)
            {
                yield return c.ToString("yyyy/MM/dd");
                c = c.AddDays(1);
            }
        }
    }
}
