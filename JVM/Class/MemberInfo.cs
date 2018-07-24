using JVM.Class.Attribute;
using JVM.Class.Constant;

namespace JVM.Class
{
    public class MemberInfo
    {
        public ushort AccessFlags { get; private set; }
        public ushort NameIndex { get; private set; }
        public string Name { get; private set; }
        public ushort DescriptorIndex { get; private set; }
        public string Descriptor { get; private set; }
        public IAttribute[] Attributes { get; private set; }
        private MemberInfo() { }

        public static MemberInfo ReadMemberInfo(ClassReader reader, ConstantPool pool)
        {
            var member = new MemberInfo()
            {
                AccessFlags = reader.ReadU2(),
                NameIndex = reader.ReadU2(),
                DescriptorIndex = reader.ReadU2(),
                Attributes = reader.ReadAttributes(pool)
            };
            member.Name = pool.GetUtf8String(member.NameIndex);
            member.Descriptor = pool.GetUtf8String(member.DescriptorIndex);
            return member;
        }

        public static MemberInfo[] ReadMembers(ClassReader reader, ConstantPool constantPool)
        {
            var count = reader.ReadU2();
            var members = new MemberInfo[count];
            for (var i = 0; i < members.Length; i++)
            {
                members[i] = ReadMemberInfo(reader, constantPool);
            }
            return members;
        }
    }
}
