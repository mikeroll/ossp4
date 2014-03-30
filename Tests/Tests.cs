using NUnit.Framework;
using System;
using System.Runtime.InteropServices;

using MapReduce;
using System.Threading.Tasks;

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

    [TestFixture]
    public class WorkloadTests
    {
        static string dmesg = @"/tmp/file";

        [Test]
        public void WorkloadInit()
        {
            using (var w = new Workload(dmesg))
            {
                //something
            }
        }

        [Test]
        public void WorkloadEnumerate()
        {
            using (var w = new Workload(dmesg))
            {
                foreach (var line in w)
                {
                    NativeStringTools.Z("kernel", line);
                }
            }
        }

        [Test]
        public void WorkloadParallelEnumerate()
        {
            using (var w = new Workload(dmesg))
            {
                // DANGER: not memory-efficient at all (?)
                Parallel.ForEach(w, (line) => {
                    NativeStringTools.Z("kernel", line);
                });
            }
        }
    }
}

