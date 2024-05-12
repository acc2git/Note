using System;
using System.Collections.Generic;

namespace ConsoleApp
{
	public class PrimesCounter
	{
		private HashSet<long> _primes = new HashSet<long> { 2 };
		private long last = 1;
		private long[] wheel = new long[] { 2, 4 };
		private int wheelIndex = 0;

		public long Next()
		{
			long num = GetNextTry(last);
			while (!IsPrime(num))
				num = GetNextTry(num);

			_primes.Add(num);
			last = num;
			return num;
		}

		private long GetNextTry(long num)
		{
			if (num < 5)
				return num + 1;
			long result = num + wheel[wheelIndex];
			wheelIndex = (wheelIndex + 1) % wheel.Length;
			return result;
		}

		public IEnumerable<long> Enumerate()
		{
			while (true)
				yield return Next();
		}

		private bool IsPrime(long num)
		{
			if (num < 2)
				return false;

			if (_primes.Contains(num))
				return true;

			long sqrt = (long)Math.Sqrt(num);
			foreach (var prime in _primes)
			{
				if (prime > sqrt)
					break;
				if (num % prime == 0)
					return false;
			}
			return true;
		}
	}
}