namespace JVM.Class.Constant.Impl
{
    public class DoubleConstantInfo : IConstantInfo
    {
        public ConstantType Type => ConstantType.Double;
        public double Value { get; }

        public DoubleConstantInfo(double val)
        {
            Value = val;
        }
    }
}