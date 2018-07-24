using JVM.Class.Attribute;

public class ExceptionTable
{
    public ushort StartPc { get; set; }
    public ushort EndPc { get; set; }
    public ushort HandlePc { get; set; }
    public ushort CatchType { get; set; }
}