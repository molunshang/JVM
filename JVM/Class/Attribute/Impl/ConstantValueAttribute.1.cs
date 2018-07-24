using JVM.Class.Attribute;
using JVM.Class.Constant;

public class ExceptionsAttribute : IAttribute
{
    public AttributeType Type => AttributeType.Exceptions;
    public ushort[] ExceptionsIndex { get; }
    public ExceptionsAttribute(ushort[] indexes)
    {
        ExceptionsIndex = indexes;
    }
}