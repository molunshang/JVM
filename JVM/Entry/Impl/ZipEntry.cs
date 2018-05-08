using System.Collections.Generic;
using System.IO;
using System.IO.Compression;

namespace JVM.Entry.Impl
{
    public class ZipEntry : IEntry
    {
        private readonly string filePath;
        private readonly Dictionary<string, string> classPathDic;

        public ZipEntry(string path)
        {
            classPathDic = new Dictionary<string, string>();
            filePath = path;
            using (var zip = ZipFile.OpenRead(filePath))
            {
                foreach (var entry in zip.Entries)
                {
                    if (!entry.FullName.EndsWith(".class"))
                    {
                        continue;
                    }
                    var file = entry.FullName;
                    var className = file.Replace('/', '.').Substring(0, file.Length - 6);
                    classPathDic.Add(className, file);
                }
            }
        }
        public byte[] ReadClass(string className)
        {
            if (!classPathDic.TryGetValue(className, out var name))
                return new byte[0];
            using (var zip = ZipFile.OpenRead(filePath))
            {
                var entry = zip.GetEntry(name);
                if (entry == null)
                {
                    return new byte[0];
                }
                using (var reader = entry.Open())
                {
                    var data = new byte[entry.Length];
                    int offset = 0, size = 0;
                    do
                    {
                        size = reader.Read(data, offset, data.Length);
                        offset += size;
                    } while (size > 0);
                    return data;
                }
            }
        }
    }
}
