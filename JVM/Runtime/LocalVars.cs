using System;

namespace JVM.Runtime
{
    public class LocalVars
    {
        private Slot[] _vars;
        private SlotArrayOperator slotArray;
        public LocalVars(ushort maxLocals)
        {
            _vars = new Slot[maxLocals];
            slotArray = new SlotArrayOperator(_vars);
        }

        public int GetInt(int index)
        {
            return slotArray.GetInt(index);
        }

        public void SetInt(int index, int num)
        {
            slotArray.SetInt(index, num);
        }

        public float GetFloat(int index)
        {
            return slotArray.GetFloat(index);
        }

        public void SetFloat(int index, float num)
        {
            slotArray.SetFloat(index, num);
        }

        public long GetLong(int index)
        {
            return slotArray.GetLong(index);
        }

        public void SetLong(int index, long num)
        {
            slotArray.SetLong(index, num);
        }

        public double GetDouble(int index)
        {
            return slotArray.GetDouble(index);
        }

        public void SetDouble(int index, double num)
        {
            slotArray.SetDouble(index, num);
        }

        public object GetRef(int index)
        {
            return slotArray.GetRef(index);
        }

        public void SetRef(int index, object refObj)
        {
            slotArray.SetRef(index, refObj);
        }
    }
}