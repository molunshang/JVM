using System;
using JVM.Class.Constant.Impl;

namespace JVM.Class.Constant
{
    public class ConstantPool
    {
        private IConstantInfo[] _constantInfos;
        public ConstantPool(ClassReader reader)
        {
            var count = reader.ReadU2();
            _constantInfos = new IConstantInfo[count];
            for (int i = 1; i < _constantInfos.Length; i++)
            {
                _constantInfos[i] = ConstantInfoFactory.CreateConstantInfo(reader, this);
                if (_constantInfos[i].Type == ConstantType.Double || _constantInfos[i].Type == ConstantType.Long)
                {
                    i++;
                }
            }
        }
        public string GetClassName(ushort classIndex)
        {
            if (classIndex == 0)
            {
                return string.Empty;
            }
            return ((ClassConstantInfo)_constantInfos[classIndex]).Name;
        }

        public string GetUtf8String(ushort classIndex)
        {
            if (classIndex == 0)
            {
                return string.Empty;
            }
            return ((Utf8ConstantInfo)_constantInfos[classIndex]).Value;
        }

        public (string Name, string Type) GetNameAndType(ushort index)
        {
            var nameAndType = (NameAndTypeConstantInfo)_constantInfos[index];
            return (this.GetUtf8String(nameAndType.NameIndex), this.GetUtf8String(nameAndType.DescriptorIndex));
        }
    }
}
