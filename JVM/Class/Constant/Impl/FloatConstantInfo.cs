﻿namespace JVM.Class.Constant.Impl
{
    public class FloatConstantInfo : IConstantInfo
    {
        public ConstantType Type => ConstantType.Float;
        public float Value { get; }

        public FloatConstantInfo(byte[] bytes)
        {
            //Value = val;
        }
    }
}