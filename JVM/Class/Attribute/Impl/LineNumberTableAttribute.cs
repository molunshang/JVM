using JVM.Class.Attribute.Entry;

namespace JVM.Class.Attribute.Impl
{
    public class LineNumberTableAttribute : IAttribute
    {
        public AttributeType Type => AttributeType.LineNumberTable;

        public LineNumberTableEntry[] TableEntryList { get; }

        public LineNumberTableAttribute(LineNumberTableEntry[] entryList)
        {
            TableEntryList = entryList;
        }
    }
}