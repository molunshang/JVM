namespace JVM.Class.Constant.Impl
{
    public class Utf8ConstantInfo : IConstantInfo
    {
        public ConstantType Type => ConstantType.Utf8;
        public string Value { get; }

        public Utf8ConstantInfo(string val)
        {
            Value = val;
        }
    }
}