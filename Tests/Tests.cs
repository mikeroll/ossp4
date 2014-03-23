using NUnit.Framework;
using System;
using System.Runtime.InteropServices;

namespace Tests
{
    [TestFixture()]
    public class ZTests
    {
        [DllImport("Z")]
        public static extern int Z(string word, string str);

        [Test]
        public void InvokeTest()
        {
            const int expected = 3;
            int actual = Z("lal","lalalalalalal");
            Assert.AreEqual(expected, actual);
        }
    }
}

