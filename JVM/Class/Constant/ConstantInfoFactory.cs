using System;
using JVM.Class.Constant.Impl;

namespace JVM.Class.Constant
{
    public class ConstantInfoFactory
    {
        public static IConstantInfo CreateConstantInfo(ClassReader reader, ConstantPool pool)
        {
            var tag = reader.ReadU1();
            var type = (ConstantType)tag;
            switch (type)
            {
                case ConstantType.Class:
                    return new ClassConstantInfo(pool, reader.ReadU2());
                case ConstantType.FieldRef:
                    break;
                case ConstantType.MethodRef:
                    break;
                case ConstantType.InterfaceMethodRef:
                    break;
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