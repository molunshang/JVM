namespace JVM.Class.Constant.Impl
{
    public class NameAndTypeConstantInfo : IConstantInfo
    {
        public ConstantType Type => ConstantType.NameAndType;
        public ushort NameIndex { get; }
        public ushort DescriptorIndex { get; }

        public NameAndTypeConstantInfo(int name, int desc)
        {
            NameIndex = name;
            DescriptorIndex = desc;
        }
    }
}