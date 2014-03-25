using System;
using System.Runtime.InteropServices;

namespace MapReduce
{
    public static class NativeStringTools
    {
        [DllImport("Z")]
        public static extern int Z(string word, string str);
    }
}

