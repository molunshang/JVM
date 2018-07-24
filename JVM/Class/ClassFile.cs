using System;
using System.Linq;
using JVM.Class.Attribute;
using JVM.Class.Constant;

namespace JVM.Class
{
    public class ClassFile
    {
        /// <summary>
        /// 版本号
        /// </summary>
        public ushort MinorVersion { get; set; }
        /// <summary>
        /// 版本号
        /// </summary>
        public ushort MajorVersion { get; set; }
        /// <summary>
        /// 常量池
        /// </summary>
        public ConstantPool ConstantPool { get; set; }
        /// <summary>
        /// 权限标记
        /// </summary>
        public ushort AccessFlags { get; set; }
        public ushort ThisClass { get; set; }
        public ushort SuperClass { get; set; }
        public ushort[] Interfaces { get; set; }
        /// <summary>
        /// 字段信息
        /// </summary>
        public MemberInfo[] Fields { get; set; }
        /// <summary>
        /// 成员方法信息
        /// </summary>
        public MemberInfo[] Methods { get; set; }
        public IAttribute[] Attributes { get; set; }
        public string ClassName { get; set; }
        public string SuperClassName { get; set; }
        public string[] InterfaceNames { get; set; }

        public static ClassFile Parse(ClassReader reader)
        {
            var magic = reader.ReadU4();
            if (magic != Constants.Magic)
            {
                throw new Exception("java.lang.ClassFormatError:magic");
            }
            ushort minorVersion = reader.ReadU2(), majorVersion = reader.ReadU2();
            switch (majorVersion)
            {
                case Constants.JDK2_MajorVersion:
                case Constants.JDK3_MajorVersion:
                case Constants.JDK4_MajorVersion:
                case Constants.JDK5_MajorVersion:
                case Constants.JDK6_MajorVersion:
                case Constants.JDK7_MajorVersion:
                case Constants.JDK8_MajorVersion:
                    if (minorVersion != 0)
                    {
                        throw new Exception("java.lang.UnsupportedClassVersionError!");
                    }
                    break;
                default:
                    throw new Exception("java.lang.UnsupportedClassVersionError!");
            }
            var pool = new ConstantPool(reader);
            var classFile = new ClassFile
            {
                MinorVersion = minorVersion,
                MajorVersion = majorVersion,
                ConstantPool = pool,
                AccessFlags = reader.ReadU2(),
                ThisClass = reader.ReadU2(),
                SuperClass = reader.ReadU2(),
                Interfaces = reader.ReadU2S()
            };
            classFile.ClassName = pool.GetClassName(classFile.ThisClass);
            classFile.SuperClassName = pool.GetClassName(classFile.SuperClass);
            classFile.Fields = MemberInfo.ReadMembers(reader, classFile.ConstantPool);
            classFile.Methods = MemberInfo.ReadMembers(reader, classFile.ConstantPool);
            classFile.Attributes = reader.ReadAttributes(classFile.ConstantPool);
            classFile.InterfaceNames = classFile.Interfaces.Select(index => classFile.ConstantPool.GetClassName(index)).ToArray();
            return classFile;
        }


    }
}
