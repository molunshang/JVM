namespace JVM.Class.Constant.Impl
{
    public class InterfaceMethodRefConstantInfo : MemberConstantInfo, IConstantInfo
    {
        public ConstantType Type => ConstantType.InterfaceMethodRef;
        public InterfaceMethodRefConstantInfo(ConstantPool pool, ushort classIndex, ushort nameTypeIndex) : base(pool, classIndex, nameTypeIndex)
        {
        }

    }
}