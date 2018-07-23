using JVM.Class.Attribute;
using JVM.Class.Constant;

public class ConstantValueAttribute : IAttribute
{
    public AttributeType Type => AttributeType.ConstantValue;
    public IConstantInfo ConstantValue { get; }
    public ConstantValueAttribute(IConstantInfo constantInfo)
    {
        ConstantValue = constantInfo;
    }
}