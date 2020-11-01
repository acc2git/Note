using System;
using System.Linq;
using NUnit.Framework;

namespace Test
{
	[TestFixture]
	class Ranges_Test
	{
        [Test]
        public void Test_Same()
        {
            int[] a = new int[] { 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
            Assert.AreEqual(a[2..2], new int[] { });
        }

        [Test]
        public void Test_2to5()
        {
            int[] a = new int[] { 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };

            // StartAt 2，EndAt 5 (不包含5)
            Assert.AreEqual(a[2..5], new int[] { 7, 8, 9 });
            Assert.AreEqual(a[new Range(new Index(2), new Index(5))], new int[] { 7, 8, 9 });
        }

        [Test]
        public void Test_FromEnd()
        {
            int[] a = new int[] { 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };

            Assert.AreEqual(a[2..^2], new int[] { 7, 8, 9, 10, 11, 12, 13 });
        }

        [Test]
        public void Test_RightShift()
        {
            int[] a = new int[] { 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };

            Assert.AreEqual(a[..^1].Prepend(a[^1]), new int[] { 15, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 });
        }

        [Test]
        public void Test_LeftShift()
        {
            int[] a = new int[] { 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };

            Assert.AreEqual(a[1..].Append(a[0]), new int[] { 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 5 });
        }

    }
}
