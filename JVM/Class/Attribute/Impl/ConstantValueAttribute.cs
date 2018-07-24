using JVM.Class.Constant;

namespace JVM.Class.Attribute.Impl
{
    public class ConstantValueAttribute : IAttribute
    {
        public AttributeType Type => AttributeType.ConstantValue;
        public IConstantInfo ConstantValue { get; }
        public ConstantValueAttribute(IConstantInfo constantInfo)
        {
            ConstantValue = constantInfo;
        }
    }
}