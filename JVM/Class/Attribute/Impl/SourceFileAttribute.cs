namespace JVM.Class.Attribute.Impl
{
    public class SourceFileAttribute : IAttribute
    {
        public AttributeType Type => AttributeType.SourceFile;
        public string FileName { get; }
        public SourceFileAttribute(string name)
        {
            FileName = name;
        }
    }
}