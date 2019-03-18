using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VM8080;

namespace VCPU8080Test
{
    [TestClass]
    public class TestMemory
    {
        [TestMethod]
        public void TestMemoryInit()
        {
            Memory memory = new Memory();

            for (int position = 0; position < memory.Size; position++)
            {
                Assert.AreEqual<byte>(0, memory.ReadByte((ushort)position));
            }
        }

        [TestMethod]
        public void TestWrite()
        {
            Memory memory = new Memory();

            Assert.AreEqual<byte>(0, memory.ReadByte(0));
            memory.WriteByte(0, byte.MaxValue);
            Assert.AreEqual<byte>(byte.MaxValue, memory.ReadByte(0));
        }
    }
}
