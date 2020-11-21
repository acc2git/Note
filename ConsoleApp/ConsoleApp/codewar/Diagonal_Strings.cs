using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp.codewar
{
	public class Diagonal_Strings
	{
		public static string[] DiagonalsOfSquare(string[] array)
		{
			if (array.Length == 0 || array.Any(x => x.Length != array.Length))
				return null;

			var sortedArray = array.OrderBy(x => x).ToArray();

			var idxMapping = sortedArray
				.Select((x, i) => new { str = x, idx = i })
				.GroupBy(x => x.str, g => g.idx)
				.ToDictionary(g => g.Key, g => new Queue<int>(g.ToArray()));

			return array.Select(str => GetDiagonal(sortedArray, idxMapping[str].Dequeue(), 0)).ToArray();
		}

		static string GetDiagonal(string[] square, int i, int j)
		{
			string result = "";
			int len = square.Length, cnt = 0;
			while (cnt < len)
			{
				result += square[(i + cnt) % len][(j + cnt) % len];
				cnt++;
			}
			return result;
		}
	}
}
