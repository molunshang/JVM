using System.Collections.Generic;
using System.IO;

namespace JVM.Entry.Impl
{
    public class DirEntry : IEntry
    {
        private readonly Dictionary<string, string> classPathDic;
        public DirEntry(string path, bool includeSub)
        {
            var classFiles = Directory.GetFiles(path, "*.class", includeSub ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly);
            classPathDic = new Dictionary<string, string>(classFiles.Length);
            for (var i = 0; i < classFiles.Length; i++)
            {
                var file = classFiles[i];
                var className = file.Replace(Path.DirectorySeparatorChar, '.').Substring(0, file.Length - 6);
                classPathDic.Add(className, file);
            }
        }
        public DirEntry(string path) : this(path, true)
        {

        }

        public byte[] ReadClass(string className)
        {
            if (classPathDic.TryGetValue(className, out var path))
            {
                return File.ReadAllBytes(path);
            }
            return new byte[0];
        }
    }
}
