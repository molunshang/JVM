namespace JVM.Class.Attribute.Impl
{
    public class CodeAttribute : IAttribute
    {
        public AttributeType Type => AttributeType.Code;
        public ushort MaxStack { get; }
        public ushort MaxLocals { get; }
        public byte[] Code { get; }
        public ExceptionTable[] ExceptionTables { get; }
        public IAttribute[] Attributes { get; }
        public CodeAttribute(ushort stack, ushort local, byte[] code, ExceptionTable[] exceptions, IAttribute[] attributes)
        {
            MaxStack = stack;
            MaxLocals = local;
            Code = code;
            ExceptionTables = exceptions;
            Attributes = attributes;
        }
    }
}