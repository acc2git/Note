using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace ConsoleApp.codewar
{
	public class WaterFowl
	{
		public static string[] CreateReport(string[] vals)
		{
			if (vals.Any(duck => Regex.IsMatch(duck, @"(?i)Labrador\s+Duck"))) // case-insensitive
				return new string[] { "Disqualified data" };

			return vals
				.Select(x => x.ToUpper().Split(new char[] { ' ', '-' }, StringSplitOptions.RemoveEmptyEntries))
				.Select(tokens => new { name = SixLetterCode(tokens[0..^1]), cnt = int.Parse(tokens[^1]) })
				.GroupBy(x => x.name)
				.OrderBy(g => g.Key)
				.SelectMany(r => new string[] { r.Key, r.Sum(x => x.cnt).ToString() })
				.ToArray();
		}

		private static string SixLetterCode(string[] words)
		{
			return words.Length switch
			{
				4 => $"{words[0].SafeSubstring(0, 1)}{words[1].SafeSubstring(0, 1)}{words[2].SafeSubstring(0, 2)}{words[3].SafeSubstring(0, 2)}",
				3 => $"{words[0].SafeSubstring(0, 2)}{words[1].SafeSubstring(0, 2)}{words[2].SafeSubstring(0, 2)}",
				2 => $"{words[0].SafeSubstring(0, 3)}{words[1].SafeSubstring(0, 3)}",
				_ => words[0].SafeSubstring(0, 6),
			};
		}
	}

	public static class Extd
	{
		public static string SafeSubstring(this string str, int startIndex, int length)
		{
			if (startIndex > str.Length)
				return "";
			int endIndex = Math.Min(startIndex + length, str.Length);
			return str.Substring(startIndex, endIndex - startIndex);
		}
	}
}
