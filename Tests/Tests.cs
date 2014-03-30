using NUnit.Framework;
using System;
using System.Runtime.InteropServices;

using MapReduce;

namespace Tests
{
    [TestFixture]
    public class ZTests
    {
        [Test]
        public void InvokeTest()
        {
            const int expected = 3;
            int actual = NativeStringTools.Z("lal","lalalalalalal");
            Assert.AreEqual(expected, actual);
        }
    }
}

