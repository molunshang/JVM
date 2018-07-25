using System.Collections.Generic;
namespace JVM.Runtime
{
    public class JvmThread
    {
        private Stack<Frame> _frameStack = new Stack<Frame>();
        public Frame CurrentFrame
        {
            get
            {
                if (_frameStack.TryPeek(out var frame))
                {
                    return frame;
                }
                return null;
            }
        }

        public int Pc { get; set; }
        public void PushFrame(Frame frame)
        {
            _frameStack.Push(frame);
        }

        public Frame PopFrame()
        {
            if (_frameStack.TryPop(out var frame))
            {
                return frame;
            }
            return null;
        }
    }
}