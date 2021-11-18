using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp.codewar
{
    public class SnailSolution
    {
        public static int[] Snail(int[][] array)
        {
            if (array.Length == 0)
                return new int[0];

            var loc = (i:0, j:0);
            List<int> result = new List<int> { array[loc.i][loc.j] };
            foreach (var d in Times(array.Length).Zip(Dirs(), (s, d) => Enumerable.Repeat(d, s)).SelectMany(x => x))
            {
                loc.i += d.i;
                loc.j += d.j;
                result.Add(array[loc.i][loc.j]);
            }

            return result.ToArray();
        }

        private static IEnumerable<(int i, int j)> Dirs()
        {
            while (true)
            {
                yield return (0, 1);
                yield return (1, 0);
                yield return (0, -1);
                yield return (-1, 0);
            }
        }

        private static IEnumerable<int> Times(int n)
        {
            if (n > 1)
            {
                n--;
                yield return n;
                yield return n;
                yield return n;
            }

            while (n > 1)
            {
                n--;
                yield return n;
                yield return n;
            }
        }
    }
}
