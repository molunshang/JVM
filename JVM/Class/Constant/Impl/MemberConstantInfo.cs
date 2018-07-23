namespace JVM.Class.Constant.Impl
{
    public abstract class MemberConstantInfo : AbstractConstantInfo
    {
        public ushort ClassIndex { get; }
        public ushort NameAndTypeIndex { get; }

        public string ClassName
        {
            get
            {
                return ConstantPool.GetClassName(ClassIndex);
            }
        }

        public string Name
        {
            get
            {
                return ConstantPool.GetNameAndType(NameAndTypeIndex).Name;
            }
        }

        public string MemberType
        {
            get
            {
                return ConstantPool.GetNameAndType(NameAndTypeIndex).Type;
            }
        }

        public MemberConstantInfo(ConstantPool pool, ushort classIndex, ushort nameTypeIndex) : base(pool)
        {
            ClassIndex = classIndex;
            NameAndTypeIndex = nameTypeIndex;
        }

    }
}