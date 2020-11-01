using System;
using System.Linq;
using NUnit.Framework;

namespace Test
{
	[TestFixture]
	class Ranges_Test
	{
        int[] a = new int[] { 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };

        [Test]
        public void Test_Get()
        {
            // a[^0] thorws Exception
            Assert.AreEqual(a[^11], 5);
            Assert.AreEqual(a[^1], 15);
        }

        [Test]
        public void Test_Same()
        {
            Assert.AreEqual(a[2..2], new int[] { });
        }

        [Test]
        public void Test_2to5()
        {
            // StartAt 2，EndAt 5 (不包含5)
            Assert.AreEqual(a[2..5], new int[] { 7, 8, 9 });
            Assert.AreEqual(a[new Range(new Index(2), new Index(5))], new int[] { 7, 8, 9 });
        }

        [Test]
        public void Test_FromEnd()
        {
            Assert.AreEqual(a[2..^2], new int[] { 7, 8, 9, 10, 11, 12, 13 });
        }

        [Test]
        public void Test_Skip()
        {
            Assert.AreEqual(a[2..], new int[] { 7, 8, 9, 10, 11, 12, 13, 14, 15 });
        }

        [Test]
        public void Test_SkipLast()
        {
            Assert.AreEqual(a[..^2], new int[] { 5, 6, 7, 8, 9, 10, 11, 12, 13 });
        }

        [Test]
        public void Test_RightShift()
        {
            Assert.AreEqual(a[..^1].Prepend(a[^1]), new int[] { 15, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 });
        }

        [Test]
        public void Test_LeftShift()
        {
            Assert.AreEqual(a[1..].Append(a[0]), new int[] { 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 5 });
        }

    }
}
