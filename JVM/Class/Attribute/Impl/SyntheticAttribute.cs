using JVM.Class.Attribute;

public class SyntheticAttribute : IAttribute
{
    public AttributeType Type => AttributeType.Synthetic;
}