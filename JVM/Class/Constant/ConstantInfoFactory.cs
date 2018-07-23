using System;
using JVM.Class.Constant.Impl;

namespace JVM.Class.Constant
{
    public class ConstantInfoFactory
    {
        public static IConstantInfo[] CreateConstantInfos(ClassReader reader, ConstantPool pool)
        {
            var count = reader.ReadU2();
            var infos = new IConstantInfo[count];
            for (int i = 1; i < infos.Length; i++)
            {
                infos[i] = ConstantInfoFactory.CreateConstantInfo(reader, pool);
                if (infos[i].Type == ConstantType.Double || infos[i].Type == ConstantType.Long)
                {
                    i++;
                }
            }
            return infos;
        }

        public static IConstantInfo CreateConstantInfo(ClassReader reader, ConstantPool pool)
        {
            var tag = reader.ReadU1();
            var type = (ConstantType)tag;
            switch (type)
            {
                case ConstantType.Class:
                    return new ClassConstantInfo(pool, reader.ReadU2());
                case ConstantType.FieldRef:
                    return new FieldRefConstantInfo(pool, reader.ReadU2(), reader.ReadU2());
                case ConstantType.MethodRef:
                    return new MethodRefConstantInfo(pool, reader.ReadU2(), reader.ReadU2());
                case ConstantType.InterfaceMethodRef:
                    return new InterfaceMethodRefConstantInfo(pool, reader.ReadU2(), reader.ReadU2());
                case ConstantType.String:
                    return new StringConstantInfo(pool, reader.ReadU2());
                case ConstantType.Integer:
                    return new IntegerConstantInfo(reader.ReadInt());
                case ConstantType.Float:
                    return new FloatConstantInfo(reader.ReadFloat());
                case ConstantType.Long:
                    return new LongConstantInfo(reader.ReadLong());
                case ConstantType.Double:
                    return new DoubleConstantInfo(reader.ReadDouble());
                case ConstantType.NameAndType:
                    return new NameAndTypeConstantInfo(reader.ReadU2(), reader.ReadU2());
                case ConstantType.Utf8:
                    return new Utf8ConstantInfo(reader.ReadUTF());
                case ConstantType.MethodHandle:
                    break;
                case ConstantType.MethodType:
                    break;
                case ConstantType.InvokeDynamic:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            throw new NotImplementedException();
        }
    }
}