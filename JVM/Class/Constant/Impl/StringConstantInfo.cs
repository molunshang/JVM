namespace JVM.Class.Constant.Impl
{
    public class StringConstantInfo : AbstractConstantInfo, IConstantInfo
    {
        public ushort Index { get; }
        public ConstantType Type => ConstantType.String;
        public string Value
        {
            get
            {
                return ConstantPool.GetUtf8String(Index);
            }
        }

        public StringConstantInfo(ConstantPool pool, ushort index) : base(pool)
        {
        }
    }
}