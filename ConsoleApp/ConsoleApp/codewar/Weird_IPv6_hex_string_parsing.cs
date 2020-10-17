using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace ConsoleApp
{
	public class Weird_IPv6_hex_string_parsing
	{
		public static string ParseIPv6(string iPv6)
			=> string.Concat(Regex.Split(iPv6, @"[^0-9A-F]").Select(x => ConvertBlock(x)));

		static int ConvertBlock(string s) => s.Select(c => Convert.ToInt32(c.ToString(), 16)).Sum();
	}
}
