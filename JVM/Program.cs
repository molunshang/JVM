using System;
using System.IO;
using JVM.Entry;
using JVM.Class;

namespace JVM
{
    class Program
    {
        static void Main(string[] args)
        {
            var jrePath = Environment.GetEnvironmentVariable("JAVA_HOME");
            var entry = EntryFactory.CreateEntry(Path.Combine(jrePath, "jre", "*"));
            var data = entry.ReadClass("java.lang.Object");
            Console.WriteLine(data);
            var reader = new ClassReader(data);//@"E:\workcode\zbj\八戒招聘\hr-saas\zbj-zhaopin-admin\zbj-hr-saas-web-manage-ui\target\classes\com\zbj\hr\listener\TaskServlet.class"
            Console.WriteLine("jvm class magic:{0}", reader.ReadU4());
        }
    }
}
