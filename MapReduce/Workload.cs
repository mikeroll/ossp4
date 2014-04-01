using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace MapReduce
{
    /// <summary>
    /// Represents the data to be processed by MapReduce
    /// </summary>
    public class Workload : IEnumerable<string>, IDisposable
    {
        public string Filename { get; private set; }
        public long Size { get; private set; }

        FileStream stream;

        /// <summary>
        /// Initializes a new instance of the <see cref="MapReduce.Workload"/> class.
        /// </summary>
        /// <param name="filename">Data file name.</param>
        public Workload(string filename)
        {
            Filename = filename;
            Size = new FileInfo(filename).Length;
            stream = File.OpenRead(filename);
            if (!stream.CanRead)
            {
                throw new IOException("Input file provided can not be read.");
            }
        }

        #region IEnumerable implementation

        //FIXME: Very long lines will break everything. No fix for now, major redesign needed.
        public IEnumerator<string> GetEnumerator()
        {
            using (var sr = new StreamReader(stream))
            {
                while (!sr.EndOfStream) 
                {
                    yield return sr.ReadLine();
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion

        #region IDisposable implementation

        public void Dispose()
        {
            stream.Dispose();
        }

        #endregion
    }
}

