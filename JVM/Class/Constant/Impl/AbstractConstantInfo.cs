namespace JVM.Class.Constant.Impl
{
    public abstract class AbstractConstantInfo
    {
        protected ConstantPool ConstantPool { get; }
        protected ushort Index { get; }
        public AbstractConstantInfo(ConstantPool pool, ushort index)
        {
            ConstantPool = pool;
            Index = index;
        }
    }
}