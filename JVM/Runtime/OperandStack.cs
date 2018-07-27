namespace JVM.Runtime
{
    public class OperandStack
    {
        private Slot[] _slots;
        private SlotArrayOperator slotArray;
        private int _index;
        public OperandStack(ushort maxStack)
        {
            _slots = new Slot[maxStack];
            slotArray = new SlotArrayOperator(_slots);
        }

        public void PushInt(int num)
        {
            slotArray.SetInt(_index, num);
            _index++;
        }

        public int PopInt()
        {
            _index--;
            return slotArray.GetInt(_index);
        }

        public void PushFloat(float num)
        {
            slotArray.SetFloat(_index, num);
            _index++;
        }

        public float PopFloat()
        {
            _index--;
            return slotArray.GetFloat(_index);
        }

        public void PushLong(long num)
        {
            slotArray.SetLong(_index, num);
            _index++;
        }

        public long PopLong()
        {
            _index--;
            return slotArray.GetLong(_index);
        }
        public void PushDouble(double num)
        {
            slotArray.SetDouble(_index, num);
            _index++;
        }

        public double PopDouble()
        {
            _index--;
            return slotArray.GetDouble(_index);
        }

        public void PushRef(object obj)
        {
            slotArray.SetRef(_index, obj);
            _index++;
        }

        public object PopRef()
        {
            _index--;
            return slotArray.GetRef(_index);
        }
    }
}