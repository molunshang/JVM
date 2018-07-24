using System;
using System.IO;
using System.Linq;
using System.Text;
using JVM.Class.Attribute;
using JVM.Class.Constant;

namespace JVM.Class
{
    public class ClassReader : IDisposable
    {
        private BinaryReader reader;

        public ClassReader(Stream stream)
        {
            reader = new BinaryReader(stream);
        }
        public ClassReader(byte[] data) : this(new MemoryStream(data))
        {

        }
        public ClassReader(string filePath) : this(File.OpenRead(filePath))
        {

        }
        public byte ReadU1()
        {
            return reader.ReadByte();
        }

        public ushort ReadU2()
        {
            var bytes = reader.ReadBytes(2);
            return (ushort)(bytes[0] << 8 | bytes[1]);
        }

        public ushort[] ReadU2S()
        {
            var num = ReadU2();
            var array = new ushort[num];
            for (int i = 0; i < num; i++)
            {
                array[i] = ReadU2();
            }
            return array;
        }

        public uint ReadU4()
        {
            var bytes = reader.ReadBytes(4);
            return (uint)(bytes[0] << 24 | bytes[1] << 16 | bytes[2] << 8 | bytes[3]);
        }

        public int ReadInt()
        {
            var bytes = reader.ReadBytes(4);
            return (bytes[0] << 24 | bytes[1] << 16 | bytes[2] << 8 | bytes[3]);
        }

        public string ReadUTF()
        {
            var length = ReadU2();
            var bytes = reader.ReadBytes(length);
            var str = new StringBuilder(length);
            for (int i = 0; i < bytes.Length; i++)
            {
                var flag = bytes[i];
                if (flag <= 127)
                {
                    str.Append((char)flag);
                }
                else if (flag >= 192 && flag <= 223)
                {
                    var flag2 = bytes[++i];
                    str.Append((char)(flag & 0x1F << 6 | flag2 & 0x3F));
                }
                else if (flag >= 224 && flag <= 239)
                {
                    var flag2 = bytes[++i];
                    var flag3 = bytes[++i];
                    str.Append((char)((flag & 0x0F) << 12 | (flag2 & 0x3F) << 6 | (flag3 & 0x3F)));
                }
                else
                {
                    throw new Exception("");
                }
            }
            return str.ToString();
        }

        public float ReadFloat()
        {
            return BitConverter.Int32BitsToSingle(ReadInt());
        }

        public ulong ReadUlong()
        {
            var bytes = reader.ReadBytes(8);
            var lo = (uint)(bytes[3] | bytes[2] << 8 | bytes[1] << 16 | bytes[0] << 24);
            var hi = (uint)(bytes[7] | bytes[6] << 8 | bytes[5] << 16 | bytes[4] << 24);
            return ((ulong)hi) << 32 | lo;
        }

        public long ReadLong()
        {
            var bytes = reader.ReadBytes(8);
            var lo = (uint)(bytes[3] | bytes[2] << 8 | bytes[1] << 16 | bytes[0] << 24);
            var hi = (long)(bytes[7] | bytes[6] << 8 | bytes[5] << 16 | bytes[4] << 24);
            return hi << 32 | lo;
        }

        public double ReadDouble()
        {
            return BitConverter.Int64BitsToDouble(ReadLong());
        }

        public byte[] ReadBytes(int length)
        {
            return reader.ReadBytes(length);
        }

        public void Dispose()
        {
            reader?.Dispose();
        }

        public ClassFile ReadClassFile()
        {
            var magic = this.ReadU4();
            if (magic != Constants.Magic)
            {
                throw new Exception("java.lang.ClassFormatError:magic");
            }
            ushort minorVersion = this.ReadU2(), majorVersion = this.ReadU2();
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
            var pool = new ConstantPool(this);
            var classFile = new ClassFile
            {
                ConstantPool = pool,
                AccessFlags = this.ReadU2(),
                ThisClass = this.ReadU2(),
                SuperClass = this.ReadU2(),
                Interfaces = this.ReadU2S()
            };
            classFile.ClassName = pool.GetClassName(classFile.ThisClass);
            classFile.SuperClassName = pool.GetClassName(classFile.SuperClass);
            classFile.Fields = MemberInfo.ReadMembers(this, classFile.ConstantPool);
            classFile.Methods = MemberInfo.ReadMembers(this, classFile.ConstantPool);
            classFile.Attributes = this.ReadAttributes(classFile.ConstantPool);
            classFile.InterfaceNames = classFile.Interfaces.Select(index => classFile.ConstantPool.GetClassName(index)).ToArray();
            return classFile;
        }
    }
}
