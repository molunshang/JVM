using System;

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
                _constantInfos[i] = ConstantInfoFactory.CreateConstantInfo(reader);
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
            throw new NotImplementedException();

        }

        public string GetUtf8String(ushort classIndex)
        {
            throw new NotImplementedException();
        }

        public (string Name, string Type) GetNameAndType(ushort index)
        {
            throw new NotImplementedException();
        }
    }
}
