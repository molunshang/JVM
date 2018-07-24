using JVM.Class.Constant.Impl;

namespace JVM.Class.Constant
{
    public class ConstantPool
    {
        private readonly IConstantInfo[] _constantInfos;
        public ConstantPool(ClassReader reader)
        {
            _constantInfos = reader.ReadConstantInfos(this);
        }

        public IConstantInfo GetConstant(ushort index)
        {
            if (index <= 0 || index >= _constantInfos.Length)
            {
                return null;
            }
            return _constantInfos[index];
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
