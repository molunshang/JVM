using System;
using System.IO;
using JVM.Entry.Impl;

namespace JVM.Entry
{
    public class EntryFactory
    {
        public static IEntry CreateEntry(string path)
        {
            if (path.IndexOf(Path.PathSeparator) > -1)
            {
                return new CompositeEntry(path);
            }
            if (path.EndsWith(".jar", StringComparison.OrdinalIgnoreCase) ||
                path.EndsWith(".zip", StringComparison.OrdinalIgnoreCase))
            {
                return new ZipEntry(path);
            }
            if (path.EndsWith("*"))
            {
                return new WildcardEntry(path);
            }
            return new DirEntry(path);
        }
    }
}
