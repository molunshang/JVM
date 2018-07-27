using System;

namespace JVM.Runtime
{
    public class SlotArrayOperator
    {
        protected Slot[] Vars { get; }
        public SlotArrayOperator(Slot[] solts)
        {
            Vars = solts;
        }
        public int GetInt(int index)
        {
            return Vars[index].Num;
        }

        public void SetInt(int index, int num)
        {
            Vars[index].Num = num;
        }

        public float GetFloat(int index)
        {
            return BitConverter.Int32BitsToSingle(Vars[index].Num);
        }

        public void SetFloat(int index, float num)
        {
            Vars[index].Num = BitConverter.SingleToInt32Bits(num);
        }

        public long GetLong(int index)
        {
            uint low = (uint)Vars[index].Num, high = (uint)Vars[index + 1].Num;
            return ((long)high << 32) | low;
        }

        public void SetLong(int index, long num)
        {
            Vars[index].Num = (int)num;
            Vars[index + 1].Num = (int)(num >> 32);
        }

        public double GetDouble(int index)
        {
            return BitConverter.Int64BitsToDouble(GetLong(index));
        }

        public void SetDouble(int index, double num)
        {
            SetLong(index, BitConverter.DoubleToInt64Bits(num));
        }

        public object GetRef(int index)
        {
            var obj = Vars[index].Ref;
            Vars[index].Ref = null;
            return obj;
        }

        public void SetRef(int index, object refObj)
        {
            Vars[index].Ref = refObj;
        }
    }
}