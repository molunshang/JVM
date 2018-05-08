using System;
using System.IO;
using JVM.Entry;

namespace JVM
{
    class Program
    {
        static void Main(string[] args)
        {
            var jrePath = Environment.GetEnvironmentVariable("JAVA_HOME");
            var entry = EntryFactory.CreateEntry(Path.Combine(jrePath, "jre"));
            var data = entry.ReadClass("java.lang.Object");
            Console.WriteLine(data);
        }
    }
}
