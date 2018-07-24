namespace JVM.Class.Attribute.Entry
{

    public class LocalVariableTableEntry
    {
        public ushort StartPc { get; set; }
        public ushort Length { get; set; }
        public ushort NameIndex { get; set; }
        public ushort DescriptorIndex { get; set; }
        public ushort Index { get; set; }
    }
}