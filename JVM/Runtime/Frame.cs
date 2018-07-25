namespace JVM.Runtime
{
    public class Frame
    {
        public Frame Next { get; set; }
        public LocalVars LocalVars { get; }
    }
}