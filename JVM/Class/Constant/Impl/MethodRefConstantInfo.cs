namespace JVM.Class.Constant.Impl
{
    public class MethodRefConstantInfo : MemberConstantInfo, IConstantInfo
    {
        public MethodRefConstantInfo(ConstantPool pool, ushort classIndex, ushort nameTypeIndex) : base(pool, classIndex, nameTypeIndex)
        {
        }

        public ConstantType Type => ConstantType.MethodRef;
    }
}