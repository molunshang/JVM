namespace JVM.Class.Constant.Impl
{
    public class FieldRefConstantInfo : MemberConstantInfo, IConstantInfo
    {
        public ConstantType Type => ConstantType.FieldRef;
        public FieldRefConstantInfo(ConstantPool pool, ushort classIndex, ushort nameTypeIndex) : base(pool, classIndex, nameTypeIndex)
        {
        }

    }
}