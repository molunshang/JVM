using System;
using JVM.Class;
using JVM.Class.Attribute.Impl;
using JVM.Class.Constant;


namespace JVM.Class.Attribute
{
    public class AttributeFactory
    {
        public static IAttribute[] CreateAttributes(ClassReader reader, ConstantPool pool)
        {
            var count = reader.ReadU2();
            var attributes = new IAttribute[count];
            for (int i = 0; i < attributes.Length; i++)
            {
                attributes[i] = CreateAttribute(reader, pool);
            }
            return attributes;
        }

        public static IAttribute CreateAttribute(ClassReader reader, ConstantPool pool)
        {
            var nameIndex = reader.ReadU2();
            var length = reader.ReadU4();
            var name = pool.GetUtf8String(nameIndex);
            if (!Enum.TryParse<AttributeType>(name, true, out var type))
            {
                throw new Exception();
            }
            switch (type)
            {
                case AttributeType.Deprecated:
                    return new DeprecatedAttribute();
                case AttributeType.Synthetic:
                    return new SyntheticAttribute();
                case AttributeType.SourceFile:
                    var fileNameIndex = reader.ReadU2();
                    return new SourceFileAttribute(pool.GetUtf8String(fileNameIndex));
                case AttributeType.ConstantValue:
                    var constantIndex = reader.ReadU2();
                    return new ConstantValueAttribute(pool.GetConstant(constantIndex));
            }
            throw new Exception();
        }
    }
}