using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp
{
    public static class Extd
    {
        public static IEnumerable<IList<TSource>> Window<TSource>(this IEnumerable<TSource> source, int size)
        {
            var iter = source.GetEnumerator();

            var window = new TSource[size];
            int i;
            for (i = 0; i < size && iter.MoveNext(); i++)
                window[i] = iter.Current;

            if (i < size)
                yield break;

            while (iter.MoveNext())
            {
                var newWindow = new TSource[size];
                Array.Copy(window, 1, newWindow, 0, size - 1);
                newWindow[size - 1] = iter.Current;

                yield return window;
                window = newWindow;
            }
            yield return window;
        }

        public static IEnumerable<T> ConcatItem<T>(this IEnumerable<T> src, T item)
        {
            foreach (var s in src)
                yield return s;
            yield return item;
        }

        public static IEnumerable<IEnumerable<T>> GroupWhile<T>(this IEnumerable<T> src, Func<T, T, bool> condition)
        {
            if (!src.Any())
                yield break;

            T prev = src.First();
            List<T> list = new List<T>() { prev };

            foreach (T item in src.Skip(1))
            {
                if (!condition(prev, item))
                {
                    yield return list;
                    list = new List<T>();
                }
                list.Add(item);
                prev = item;
            }
            yield return list;
        }

        public static IEnumerable<T> RepeatCyclical<T>(this IEnumerable<T> src)
        {
            while (true)
            {
                foreach (var item in src)
                    yield return item;
            }
        }

        public static bool IsWholeNumber(this double number)
        {
            return Math.Abs(number - Math.Truncate(number)) < Double.Epsilon;
        }
    }
}
