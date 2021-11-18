using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp.codewar
{
	public class Scramblies
	{
		public static bool Scramble(string str1, string str2)
		{
			// returns true if a portion of str1 characters can be rearranged to match str2, otherwise returns false
			var d1 = str1.ToCharCountDic();
			var d2 = str2.ToCharCountDic();
			return d2.All(x => d1.ContainsKey(x.Key) && d1[x.Key] >= d2[x.Key]);
		}

	}

	public static class Scramblies_Extd
	{
		public static Dictionary<char, int> ToCharCountDic(this string str)
		{
			return str.GroupBy(x => x).ToDictionary(g => g.Key, g => g.Count());
		}
	}
}
