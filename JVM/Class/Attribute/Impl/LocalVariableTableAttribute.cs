using JVM.Class.Attribute.Entry;

namespace JVM.Class.Attribute.Impl
{
    public class LocalVariableTableAttribute : IAttribute
    {
        public AttributeType Type => AttributeType.LocalVariableTable;
        public LocalVariableTableEntry[] TableEntryList { get; }
        public LocalVariableTableAttribute(LocalVariableTableEntry[] entryList)
        {
            TableEntryList = entryList;
        }
    }
}