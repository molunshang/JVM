using System;
using System.Collections.Generic;
using System.IO;

namespace JVM.Entry.Impl
{
    public class CompositeEntry : IEntry
    {
        private IList<IEntry> entries;
        public CompositeEntry(string path)
        {
            var paths = path.Split(Path.PathSeparator, StringSplitOptions.RemoveEmptyEntries);
            entries = new IEntry[paths.Length];
            for (var i = 0; i < paths.Length; i++)
            {
                var entryPath = paths[i];
                entries[i] = EntryFactory.CreateEntry(entryPath);
            }
        }

        public byte[] ReadClass(string className)
        {
            foreach (var entry in entries)
            {
                var data = entry.ReadClass(className);
                if (data != null && data.Length > 0)
                {
                    return data;
                }
            }
            return new byte[0];
        }
    }
}
