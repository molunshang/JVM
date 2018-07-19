using System;
using JVM.Class.Constant.Impl;

namespace JVM.Class.Constant
{
    public class ConstantInfoFactory
    {
        public static IConstantInfo CreateConstantInfo(ClassReader reader)
        {
            var tag = reader.ReadU1();
            var type = (ConstantType)tag;
            switch (type)
            {
                case ConstantType.Class:
                    break;
                case ConstantType.FieldRef:
                    break;
                case ConstantType.MethodRef:
                    break;
                case ConstantType.InterfaceMethodRef:
                    break;
                case ConstantType.String:
                    break;
                case ConstantType.Integer:
                    return new IntegerConstantInfo(reader.ReadBytes(4));
                case ConstantType.Float:
                    return new FloatConstantInfo(reader.ReadBytes(4));
                case ConstantType.Long:
                    return new LongConstantInfo(reader.ReadBytes(8));
                case ConstantType.Double:
                    break;
                case ConstantType.NameAndType:
                    break;
                case ConstantType.Utf8:
                    break;
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