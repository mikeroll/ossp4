using NUnit.Framework;
using System;
using System.Runtime.InteropServices;

namespace Tests
{
    [TestFixture()]
    public class ZTests
    {
        [DllImport("Z")]
        public static extern int Z(int i);

        [Test]
        public void InvokeTest()
        {
            const int expected = 42 * 41;
            int actual = Z(42);
            Assert.AreEqual(expected, actual);
        }
    }
}

