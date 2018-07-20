namespace JVM.Class.Constant.Impl
{
    public class IntegerConstantInfo : IConstantInfo
    {
        public ConstantType Type => ConstantType.Integer;
        public int Data { get; private set; }

        public IntegerConstantInfo(int val)
        {
            Data = val;
        }
    }
}