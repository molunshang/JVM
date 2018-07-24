namespace JVM.Class.Attribute.Impl
{
    public class SyntheticAttribute : IAttribute
    {
        public AttributeType Type => AttributeType.Synthetic;
    }
}