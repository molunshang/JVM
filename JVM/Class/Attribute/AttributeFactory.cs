using System;
using JVM.Class.Attribute.Entry;
using JVM.Class.Attribute.Impl;
using JVM.Class.Constant;


namespace JVM.Class.Attribute
{
    public static class AttributeFactory
    {
        private static ExceptionTable[] ReadExceptionTables(this ClassReader reader)
        {
            var count = reader.ReadU2();
            var tables = new ExceptionTable[count];
            for (int i = 0; i < tables.Length; i++)
            {
                tables[i] = new ExceptionTable()
                {
                    StartPc = reader.ReadU2(),
                    EndPc = reader.ReadU2(),
                    HandlePc = reader.ReadU2(),
                    CatchType = reader.ReadU2()
                };
            }
            return tables;
        }

        private static LineNumberTableEntry[] ReadLineNumberTableEntrys(this ClassReader reader)
        {
            var count = reader.ReadU2();
            var tables = new LineNumberTableEntry[count];
            for (var i = 0; i < tables.Length; i++)
            {
                tables[i] = new LineNumberTableEntry()
                {
                    StartPc = reader.ReadU2(),
                    LineNumber = reader.ReadU2()
                };
            }
            return tables;
        }

        private static LocalVariableTableEntry[] ReadLocalVariableTableEntrys(this ClassReader reader)
        {
            var count = reader.ReadU2();
            var tables = new LocalVariableTableEntry[count];
            for (var i = 0; i < tables.Length; i++)
            {
                tables[i] = new LocalVariableTableEntry()
                {
                    StartPc = reader.ReadU2(),
                    Length = reader.ReadU2(),
                    NameIndex = reader.ReadU2(),
                    DescriptorIndex = reader.ReadU2(),
                    Index = reader.ReadU2()
                };
            }
            return tables;
        }

        public static IAttribute[] ReadAttributes(this ClassReader reader, ConstantPool pool)
        {
            var count = reader.ReadU2();
            var attributes = new IAttribute[count];
            for (int i = 0; i < attributes.Length; i++)
            {
                attributes[i] = ReadAttribute(reader, pool);
            }
            return attributes;
        }

        public static IAttribute ReadAttribute(this ClassReader reader, ConstantPool pool)
        {
            var nameIndex = reader.ReadU2();
            var length = reader.ReadU4();
            var name = pool.GetUtf8String(nameIndex);
            if (!Enum.TryParse<AttributeType>(name, true, out var type))
            {
                type = AttributeType.Unparsed;
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
                case AttributeType.Code:
                    ushort stack = reader.ReadU2(), locals = reader.ReadU2();
                    var codelength = reader.ReadU4();
                    var code = reader.ReadBytes((int)codelength);
                    return new CodeAttribute(stack, locals, code, ReadExceptionTables(reader), ReadAttributes(reader, pool));
                case AttributeType.Exceptions:
                    return new ExceptionsAttribute(reader.ReadU2S());
                case AttributeType.LineNumberTable:
                    return new LineNumberTableAttribute(ReadLineNumberTableEntrys(reader));
                case AttributeType.LocalVariableTable:
                    return new LocalVariableTableAttribute(ReadLocalVariableTableEntrys(reader));
            }
            return new UnparsedAttribute(reader.ReadBytes((int)length));
        }
    }
}