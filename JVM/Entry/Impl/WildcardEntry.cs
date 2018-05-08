using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace JVM.Entry.Impl
{
    public class WildcardEntry : IEntry
    {
        private readonly IList<IEntry> entries;
        public WildcardEntry(string path)
        {
            var realPath = path.TrimEnd('*');
            var jars = Directory.GetFiles(realPath, "*.*", SearchOption.AllDirectories).Where(f => f.EndsWith(".jar", StringComparison.OrdinalIgnoreCase) || f.EndsWith(".zip", StringComparison.OrdinalIgnoreCase)).ToArray();
            entries = new IEntry[jars.Length + 1];
            entries[0] = EntryFactory.CreateEntry(realPath);
            for (var i = 0; i < jars.Length; i++)
            {
                var entryPath = jars[i];
                entries[i + 1] = EntryFactory.CreateEntry(entryPath);
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
