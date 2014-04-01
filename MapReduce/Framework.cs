using System.Linq;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using System.Threading;

namespace MapReduce
{
    public static class Framework
    {
        static KeyValuePair<string, int> Map(string word, string line)
        {
            int occurrences = NativeStringTools.Z(word, line);
            return new KeyValuePair<string, int>(word, occurrences);
        }

        static int Reduce(KeyValuePair<string, IEnumerable<int>> reduceItem)
        {
            return reduceItem.Value.Sum();
        }

        public static int Process(Workload input, string word)
        {
            var mapResults = new ConcurrentBag<KeyValuePair<string, int>>();

            Parallel.ForEach(input, (line) =>
            {
                mapResults.Add(Map(word, line));
            });

            var reduceSources = mapResults.GroupBy(
                item => item.Key,
                (key, values) => new KeyValuePair<string, IEnumerable<int>>(key, values.Select(i=>i.Value)));

            int totalCount = 0;
            Parallel.ForEach(reduceSources, (kvp) => {
                Interlocked.Add(ref totalCount, Reduce(kvp));
            });

            return totalCount;
        }
    }
}

