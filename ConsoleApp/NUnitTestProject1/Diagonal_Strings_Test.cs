using ConsoleApp.codewar;
using NUnit.Framework;

namespace Test
{
	[TestFixture]
	public class Diagonal_Strings_Test
	{
        [Test]
        public void Test()
        {
            string[] test1 = new string[] { "abcd", "kata", "1234", "qwer" };
            string[] expected1 = new string[] { "aae4", "kw3d", "1btr", "q2ca" };
            Assert.AreEqual(expected1, Diagonal_Strings.DiagonalsOfSquare(test1));

            string[] test2 = new string[] { "1a8er", "B36jh", "AiYe3", "B1t0a", "g47uj" };
            string[] expected2 = new string[] { "1itjj", "B48ea", "A16ur", "B37e3", "gaY0h" };
            Assert.AreEqual(expected2, Diagonal_Strings.DiagonalsOfSquare(test2));

            string[] test3 = new string[] { "ab", "12" };
            string[] expected3 = new string[] { "a2", "1b" };
            Assert.AreEqual(expected3, Diagonal_Strings.DiagonalsOfSquare(test3));

            string[] test4 = new string[] { "xyz", "xyz", "xyz" };
            string[] expected4 = new string[] { "xyz", "xyz", "xyz" };
            Assert.AreEqual(expected4, Diagonal_Strings.DiagonalsOfSquare(test4));

            string[] test5 = new string[] { "abcd", "kata", "abcd", "qwer" };
            string[] expected5 = new string[] { "abtr", "kwcd", "aaed", "qbca" };
            Assert.AreEqual(expected5, Diagonal_Strings.DiagonalsOfSquare(test5));
        }
    }
}
