using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace JVM.Class
{
    public class MemberInfo
    {
        public ushort AccessFlags { get; set; }
        public ushort NameIndex { get; set; }
        public ushort DescriptorIndex { get; set; }
        public AttributeInfo[] Attributes { get; set; }
    }
}
