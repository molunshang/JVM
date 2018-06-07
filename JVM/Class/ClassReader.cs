using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

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

        public ulong ReadUlong()
        {
            var bytes = reader.ReadBytes(8);
            var lo = (uint)(bytes[3] | bytes[2] << 8 | bytes[1] << 16 | bytes[0] << 24);
            var hi = (uint)(bytes[7] | bytes[6] << 8 | bytes[5] << 16 | bytes[4] << 24);
            return ((ulong)hi) << 32 | lo;
        }

        public byte[] ReadBytes(int length)
        {
            return reader.ReadBytes(length);
        }

        public void Dispose()
        {
            reader?.Dispose();
        }
    }
}
