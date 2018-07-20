namespace JVM.Class.Constant.Impl
{
    public class ClassConstantInfo : AbstractConstantInfo, IConstantInfo
    {
        public ConstantType Type => ConstantType.Class;
        public ushort Index { get; }
        public string Name
        {
            get
            {
                return ConstantPool.GetUtf8String(Index);
            }
        }

        public ClassConstantInfo(ConstantPool pool, ushort index) : base(pool)
        {
            Index = index;
        }
    }
}