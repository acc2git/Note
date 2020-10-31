using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp
{
    // https://www.codewars.com/kata/5512ec4bbe2074421d00028c

    /*
        A Stream is an infinite sequence of items. It is defined recursively
        as a head item followed by the tail, which is another stream.
        Consequently, the tail has to be wrapped with Lazy to prevent
        evaluation.
    */
    public class Stream<T>
    {
        public readonly T Head;
        public readonly Lazy<Stream<T>> Tail;

        public Stream(T head, Lazy<Stream<T>> tail)
        {
            Head = head;
            Tail = tail;
        }
    }

    public static class Stream
    {

        public static Stream<T> Cons<T>(T h, Func<Stream<T>> t)
        {
            return new Stream<T>(h, new Lazy<Stream<T>>(() => t()));
        }

        // Construct a stream by repeating a value.
        public static Stream<T> Repeat<T>(T x)
        {
            return Cons(x, () => Repeat(x));
        }

        // Construct a stream by repeatedly applying a function.
        public static Stream<T> Iterate<T>(Func<T, T> f, T x)
        {
            return Cons(x, () => Iterate(f, f(x)));
        }

        // Construct a stream by repeating an enumeration forever.
        public static Stream<T> Cycle<T>(IEnumerable<T> a)
        {
            var a0 = a.First();
            return Cons(a0, () => Cycle(a.Skip(1).Append(a0)));
        }

        // Construct a stream by counting numbers starting from a given one.
        public static Stream<int> From(int x)
        {
            return Cons(x, () => From(x + 1));
        }

        // Same as From but count with a given step width.
        public static Stream<int> FromThen(int x, int d)
        {
            return Cons(x, () => FromThen(x + d, d));
        }


        /*
            Being applied to a stream (x1, x2, x3, ...), Foldr shall return
            f(x1, f(x2, f(x3, ...))). Foldr is a right-associative fold.
            Thus applications of f are nested to the right.
        */
        public static U Foldr<T, U>(this Stream<T> s, Func<T, Func<U>, U> f)
        {
            return f(s.Head, () => s.Next().Foldr(f));
        }

        // Filter stream with a predicate function.
        public static Stream<T> Filter<T>(this Stream<T> s, Predicate<T> p)
        {
            if (p.Invoke(s.Head))
                return Cons(s.Head, () => s.Next().Filter(p));
            return s.Next().Filter(p);
        }

        // Returns a given amount of elements from the stream.
        public static IEnumerable<T> Take<T>(this Stream<T> s, int n)
        {
            while (n > 0)
            {
                yield return s.Head;
                s = s.Next();
                n--;
            }
        }

        // Drop a given amount of elements from the stream.
        public static Stream<T> Drop<T>(this Stream<T> s, int n)
        {
            while (n > 0)
            {
                s = s.Next();
                n--;
            }
            return s;
        }

        // Combine 2 streams with a function.
        public static Stream<R> ZipWith<T, U, R>(this Stream<T> s, Func<T, U, R> f, Stream<U> other)
        {
            return Cons(f(s.Head, other.Head), () => s.Next().ZipWith(f, other.Next()));
        }

        // Map every value of the stream with a function, returning a new stream.
        public static Stream<U> FMap<T, U>(this Stream<T> s, Func<T, U> f)
        {
            return Cons(f(s.Head), () => s.Next().FMap(f));
        }

        // Return the stream of all fibonacci numbers.
        public static Stream<int> Fib(List<int> s = null)
        {
            s = s ?? new List<int> { };
            if (s.Count == 0)
                s.Add(0);
            else if (s.Count == 1)
                s.Add(1);
            else
                s.Add(s[s.Count - 1] + s[s.Count - 2]);

            return Cons(s.Last(), () => Fib(s));
        }

        // Return the stream of all prime numbers.
        public static Stream<int> Primes(List<int> s = null)
        {
            s = s ?? new List<int> { };
            if (s.Count == 0)
                s.Add(2);
            else
            {
                int num = s.Last() + 1;
                while (!IsPrime(num, s))
                    num++;

                s.Add(num);
            }
            return Cons(s.Last(), () => Primes(s));
        }

        public static Stream<T> Next<T>(this Stream<T> s)
        {
            s = s.Tail.Value;
            return s;
        }

        private static bool IsPrime(int num, List<int> primes)
        {
            if (num < 2)
                return false;
            int chkEnd = (int)Math.Sqrt(num);

            foreach (var p in primes)
            {
                if (p > chkEnd)
                    break;
                if (num % p == 0)
                    return false;
            }
            return true;
        }

        public static IEnumerable<Stream<T>> AsEnumerable<T>(this Stream<T> s)
        {
            while (true)
            {
                yield return s;
                s = s.Next();
            }
        }
    }
}
