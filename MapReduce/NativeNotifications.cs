using System.Runtime.InteropServices;

namespace MapReduce
{
    public static class NativeNotifications
    {
        [DllImport("libc")]
        public static extern void puts(string s);
    }
}

