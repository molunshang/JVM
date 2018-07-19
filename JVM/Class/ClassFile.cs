using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using JVM.Class.Constant;

namespace JVM.Class
{
    public class ClassFile
    {
        /// <summary>
        /// 魔数（文件类型标识）
        /// </summary>
        public uint Magic { get; set; }
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
        public AttributeInfo[] Attributes { get; private set; }
        public string ClassName { get; set; }
        public string SuperClassName { get; set; }
        public string[] InterfaceNames { get; set; }

        private static AttributeInfo[] ReadAttributes(ClassReader reader, ConstantPool constantPool)
        {
            throw new NotImplementedException();
        }

        private static MemberInfo[] ReadMembers(ClassReader reader, ConstantPool constantPool)
        {
            throw new NotImplementedException();
        }

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

            var classFile = new ClassFile();
            classFile.ConstantPool = new ConstantPool(reader);
            classFile.AccessFlags = reader.ReadU2();
            classFile.ThisClass = reader.ReadU2();
            classFile.SuperClass = reader.ReadU2();
            classFile.Interfaces = reader.ReadU2S();
            classFile.Fields = ReadMembers(reader, classFile.ConstantPool);
            classFile.Methods = ReadMembers(reader, classFile.ConstantPool);
            classFile.Attributes = ReadAttributes(reader, classFile.ConstantPool);
            classFile.ClassName = classFile.ConstantPool.GetClassName(classFile.ThisClass);
            classFile.SuperClassName = classFile.ConstantPool.GetClassName(classFile.SuperClass);
            classFile.InterfaceNames = classFile.Interfaces.Select(index => classFile.ConstantPool.GetClassName(index)).ToArray();
            return classFile;
        }


    }
}
