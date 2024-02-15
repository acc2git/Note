using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp.practice
{
	public class DateRangePrefixSolution
	{
		public List<string> date_range_prefix(DateTime start, DateTime end)
		{
			// across multiple years -> start year, years between start and end, end year
			if (start.Year != end.Year)
				return date_range_prefix(start, new DateTime(start.Year, 12, 31))
					.Concat(RangeBetween(start.Year + 1, end.Year - 1).Select(year => RtnResult(year)))
					.Concat(date_range_prefix(new DateTime(end.Year, 1, 1), end))
					.ToList();

			// same year and full year
			if (start.Month == 1 && start.Day == 1 && end.Month == 12 && end.Day == 31)
				return new List<string> { RtnResult(start.Year) };

			// same year and across multiple months -> start month, months between start and end, end month
			var lastDayForStartMonth = EndOfMonth(start);
			if (start.Month != end.Month)
				return date_range_prefix(start, lastDayForStartMonth)
					.Concat(RangeBetween(start.Month + 1, end.Month - 1).Select(month => RtnResult(start.Year, month)))
					.Concat(date_range_prefix(new DateTime(end.Year, end.Month, 1), end))
					.ToList();

			// same year and same month and full month
			if (start.Day == 1 && end.Day == EndOfMonth(end).Day)
				return new List<string> { RtnResult(start.Year, start.Month) };

			// same year and same month -> list days
			return RangeBetween(start.Day, end.Day).Select(day => RtnResult(start.Year, start.Month, day)).ToList();
		}

		private IEnumerable<int> RangeBetween(int s, int e)
		{
			for (int i = s; i <= e; i++)
				yield return i;
		}

		private string RtnResult(int y, int? m = null, int? d = null)
		{
			if (m == null && d == null)
				return $"{y:0000}";
			if (d == null)
				return $"{y:0000}/{m:00}";
			return $"{y:0000}/{m:00}/{d:00}";
		}

		private DateTime EndOfMonth(DateTime date)
		{
			return new DateTime(date.Year, date.Month, 1).AddMonths(1).AddDays(-1);
		}
	}
}
