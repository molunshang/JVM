namespace JVM.Class.Attribute.Impl
{
    public class ExceptionsAttribute : IAttribute
    {
        public AttributeType Type => AttributeType.Exceptions;
        public ushort[] ExceptionsIndex { get; }
        public ExceptionsAttribute(ushort[] indexes)
        {
            ExceptionsIndex = indexes;
        }
    }
}