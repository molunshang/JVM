namespace JVM.Class.Constant.Impl
{
    public class LongConstantInfo : IConstantInfo
    {
        public ConstantType Type => ConstantType.Long;
        public int Value { get; }

        public LongConstantInfo(byte[] bytes)
        {
            //Value = val;
        }
    }
}