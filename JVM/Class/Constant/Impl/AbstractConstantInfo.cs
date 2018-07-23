namespace JVM.Class.Constant.Impl
{
    public abstract class AbstractConstantInfo
    {
        protected ConstantPool ConstantPool { get; }
        public AbstractConstantInfo(ConstantPool pool)
        {
            ConstantPool = pool;
        }
    }
}