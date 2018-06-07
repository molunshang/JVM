using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

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
        public static ClassFile Parse(ClassReader reader)
        {
            var magic = reader.ReadU4();
            if (magic != Constants.Magic)
            {
                throw new Exception("java.lang.ClassFormatError:magic");
            }

            var classFile = new ClassFile();
            classFile.AccessFlags = reader.ReadU2();
            classFile.SuperClass = reader.ReadU2();
            classFile.Interfaces = reader.ReadU2S();
            classFile.Attributes = new AttributeInfo[0];
            return classFile;
        }
    }
}
