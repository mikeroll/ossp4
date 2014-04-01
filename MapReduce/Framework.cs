using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

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

            var po = new ParallelOptions { MaxDegreeOfParallelism = Environment.ProcessorCount };

            Parallel.ForEach(input, po, (line) => {
                var m = Map(word, line);
                if (m.Value != 0)
                    mapResults.Add(m);
            });

            var reduceSources = mapResults.GroupBy(
                item => item.Key,
                (key, values) => new KeyValuePair<string, IEnumerable<int>>(key, values.Select(i=>i.Value)));

            int totalCount = 0;
            Parallel.ForEach(reduceSources, (kvp) =>
            {
                Interlocked.Add(ref totalCount, Reduce(kvp));
            });
                    
            return totalCount;
        }
    }
}

