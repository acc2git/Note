using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp
{
	public static class Func
	{
        public static int Gcd(int a, int b)
        {
            return b == 0 ? a : Gcd(b, a % b);
        }

        public static int Gcds(params int[] nums)
        {
            return nums.Aggregate(Gcd);
        }

        public static int Lcm(int a, int b)
        {
            return a * b / Gcd(a, b);
        }

        public static int Lcms(params int[] nums)
        {
            return nums.Aggregate(Lcm);
        }

    }
}
