using System;
using System.Collections.Generic;

namespace ConsoleApp
{
	public class PrimesCounter
	{
		List<int> _primes = new List<int> { };
		int nextIdx = 0;

		public int Next()
		{
			if (nextIdx >= 0 && nextIdx < _primes.Count)
				return _primes[nextIdx++];

			int num = _primes.Count > 0 ? _primes[^1] + 1 : 2;
			while (!IsPrime(num))
				num++;

			_primes.Add(num);
			return _primes[nextIdx++];
		}

		public IEnumerable<int> Enumerate()
		{
			while (true)
				yield return Next();
		}

		public void ResetIdx() => nextIdx = 0;

		private bool IsPrime(int num)
		{
			if (num < 2)
				return false;

			if (_primes.Contains(num))
				return true;

			int m = (int)Math.Sqrt(num);
			foreach (var p in _primes)
			{
				if (p > m)
					break;
				if (num % p == 0)
					return false;
			}
			return true;
		}
	}
}