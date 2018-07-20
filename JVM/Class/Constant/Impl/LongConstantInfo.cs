namespace JVM.Class.Constant.Impl
{
    public class LongConstantInfo : IConstantInfo
    {
        public ConstantType Type => ConstantType.Long;
        public long Value { get; }

        public LongConstantInfo(long val)
        {
            Value = val;
        }
    }
}