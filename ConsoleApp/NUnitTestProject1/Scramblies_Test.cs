﻿using ConsoleApp.codewar;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
	[TestFixture]
	public class Scramblies_Test
	{
        private static void testing(bool actual, bool expected)
        {
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public static void test1()
        {
            testing(Scramblies.Scramble("rkqodlw", "world"), true);
            testing(Scramblies.Scramble("cedewaraaossoqqyt", "codewars"), true);
            testing(Scramblies.Scramble("katas", "steak"), false);
            testing(Scramblies.Scramble("scriptjavx", "javascript"), false);
            testing(Scramblies.Scramble("scriptingjava", "javascript"), true);
            testing(Scramblies.Scramble("scriptsjava", "javascripts"), true);
            testing(Scramblies.Scramble("javscripts", "javascript"), false);
            testing(Scramblies.Scramble("aabbcamaomsccdd", "commas"), true);
            testing(Scramblies.Scramble("commas", "commas"), true);
            testing(Scramblies.Scramble("sammoc", "commas"), true);
        }
    }
}
