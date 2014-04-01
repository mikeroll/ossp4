using System;
using System.IO;

namespace MapReduce
{
    public static class Application
    {
        public static void Main(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine(@"Usage: MapReduce.exe <file> <word>.");
                return;
            }
            string file = args[0];
            string word = args[1];
            if (!File.Exists(file))
            {
                Console.WriteLine("File {0} not found.", file);
                return;
            }
            var occurrences = 0;
            try
            {
                using (var input = new Workload(file))
                {
                    occurrences = Framework.Process(input, word);
                }
                NativeNotifications.puts(occurrences.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}

