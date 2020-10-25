using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace ConsoleApp.codewar
{
    public class Create_Phone_Number
	{
		public static string CreatePhoneNumber(int[] numbers) 
			=> $"({TakeString(numbers, 0, 3)}) {TakeString(numbers, 3, 3)}-{TakeString(numbers, 6, 4)}";

		/// <summary> array slice </summary>
		public static string TakeString<T>(T[] ary, int start, int take)
			=> string.Concat(new ArraySegment<T>(ary, start, take));

		/// <summary> list slice </summary>
		public static string TakeString<T>(List<T> lst, int start, int take)
			=> string.Concat(lst.GetRange(start, take));

		// other
		public static string CreatePhoneNumber_2(int[] numbers) 
			=> long.Parse(string.Concat(numbers)).ToString("(000) 000-0000");

		public static string CreatePhoneNumber_3(int[] numbers)
			=> new Regex("(...)(...)(....)").Replace(string.Concat(numbers), "($1) $2-$3");

		public static string CreatePhoneNumber_4(int[] numbers) 
			=> string.Format("({0}{1}{2}) {3}{4}{5}-{6}{7}{8}{9}", numbers.Select(x => x.ToString()).ToArray());
	}
}
