namespace JVM.Runtime
{
    public class LocalVars
    {
        private ushort _maxLocals;
        public LocalVars(ushort maxLocals)
        {
            _maxLocals = maxLocals;
        }
    }
}