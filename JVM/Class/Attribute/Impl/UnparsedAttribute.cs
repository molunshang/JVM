namespace JVM.Class.Attribute.Impl
{
    public class UnparsedAttribute : IAttribute
    {
        public UnparsedAttribute(byte[] info)
        {
            Info = info;
        }

        public AttributeType Type => AttributeType.Synthetic;
        public byte[] Info { get; private set; }
    }
}