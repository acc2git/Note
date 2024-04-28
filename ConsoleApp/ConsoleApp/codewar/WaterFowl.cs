using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp.codewar
{
	public class WaterFowl
	{
		public static string[] CreateReport(string[] vals)
		{
			bool isValid = true;
			IEnumerable<string> summaryToOutput()
			{
				foreach (var s in ParseToRecords(vals).GroupBy(x => x.name).OrderBy(g => g.Key))
				{
					isValid = isValid && s.All(x => x.isValid);
					yield return s.Key;
					yield return s.Sum(x => x.cnt).ToString();
				}
			};
			var result = summaryToOutput().ToArray();
			return isValid ? result : new string[] { "Disqualified data" };
		}

		private static IEnumerable<(string name, bool isValid, int cnt)> ParseToRecords(string[] vals)
		{
			foreach (string val in vals)
			{
				var tokens = val.ToUpper().Split(new char[] { ' ', '-' }, StringSplitOptions.RemoveEmptyEntries);
				var words = tokens.Take(tokens.Length - 1).ToArray();
				int cnt = Int32.Parse(tokens[^1]);
				yield return (SixLetterCode(words), IsValid(words), cnt);
			}
		}

		private static bool IsValid(string[] words)
		{
			if (words.Length != 2)
				return true;
			return words[0] != "LABRADOR" || words[1] != "DUCK";
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
