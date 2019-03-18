using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VM8080;

namespace VCPU8080Test
{
    [TestClass]
    public class TestInstructions
    {
        [TestMethod]
        public void TestNOPs()
        {
            Memory memory = new Memory();
            CPU cpu = new CPU();
            TestCPU.ResetCPU(cpu);

            Assert.AreEqual<byte>(0, cpu.A);
            Assert.AreEqual<byte>(0, cpu.B);
            Assert.AreEqual<byte>(0, cpu.C);
            Assert.AreEqual<byte>(0, cpu.D);
            Assert.AreEqual<byte>(0, cpu.E);
            Assert.AreEqual<byte>(0, cpu.H);
            Assert.AreEqual<byte>(0, cpu.L);
            Assert.AreEqual<byte>(2, cpu.Flags);
            Assert.AreEqual<ushort>(0, cpu.SP);
            Assert.AreEqual<ushort>(0, cpu.PC);

            for (int position = 0; position < memory.Size; position++)
            {
                Assert.AreEqual<byte>(0, memory.ReadByte((ushort)position));
            }

            Instructions.NOP_00(cpu, memory);
            Instructions.NOP_08(cpu, memory);
            Instructions.NOP_10(cpu, memory);
            Instructions.NOP_18(cpu, memory);
            Instructions.NOP_20(cpu, memory);
            Instructions.NOP_28(cpu, memory);
            Instructions.NOP_30(cpu, memory);
            Instructions.NOP_38(cpu, memory);
            Assert.AreEqual(false, cpu.Halted);
            Instructions.HLT_76(cpu, memory);
            Assert.AreEqual(true, cpu.Halted);

            Assert.AreEqual<byte>(0, cpu.A);
            Assert.AreEqual<byte>(0, cpu.B);
            Assert.AreEqual<byte>(0, cpu.C);
            Assert.AreEqual<byte>(0, cpu.D);
            Assert.AreEqual<byte>(0, cpu.E);
            Assert.AreEqual<byte>(0, cpu.H);
            Assert.AreEqual<byte>(0, cpu.L);
            Assert.AreEqual<byte>(2, cpu.Flags);
            Assert.AreEqual<ushort>(0, cpu.SP);
            Assert.AreEqual<ushort>(0, cpu.PC);

            for (int position = 0; position < memory.Size; position++)
            {
                Assert.AreEqual<byte>(0, memory.ReadByte((ushort)position));
            }
        }

        [TestMethod]
        public void TestMVIs()
        {
            Memory memory = new Memory();
            CPU cpu = new CPU();
            TestCPU.ResetCPU(cpu);

            Assert.AreEqual<byte>(0, cpu.B);
            Assert.AreEqual<ushort>(0, cpu.PC);
            memory.WriteByte(cpu.PC, byte.MaxValue);
            Instructions.MVI_06(cpu, memory);
            Assert.AreEqual(byte.MaxValue, cpu.B);
            Assert.AreEqual<ushort>(1, cpu.PC);

            Assert.AreEqual<byte>(0, cpu.C);
            memory.WriteByte(cpu.PC, byte.MaxValue - 10);
            Instructions.MVI_0e(cpu, memory);
            Assert.AreEqual(byte.MaxValue - 10, cpu.C);
            Assert.AreEqual<ushort>(2, cpu.PC);

            Assert.AreEqual<byte>(0, cpu.D);
            memory.WriteByte(cpu.PC, byte.MaxValue - 1);
            Instructions.MVI_16(cpu, memory);
            Assert.AreEqual(byte.MaxValue - 1, cpu.D);
            Assert.AreEqual<ushort>(3, cpu.PC);

            Assert.AreEqual<byte>(0, cpu.E);
            memory.WriteByte(cpu.PC, byte.MaxValue - 20);
            Instructions.MVI_1e(cpu, memory);
            Assert.AreEqual(byte.MaxValue - 20, cpu.E);
            Assert.AreEqual<ushort>(4, cpu.PC);

            Assert.AreEqual<byte>(0, cpu.H);
            memory.WriteByte(cpu.PC, byte.MaxValue - 2);
            Instructions.MVI_26(cpu, memory);
            Assert.AreEqual(byte.MaxValue - 2, cpu.H);
            Assert.AreEqual<ushort>(5, cpu.PC);

            Assert.AreEqual<byte>(0, cpu.L);
            memory.WriteByte(cpu.PC, byte.MaxValue - 30);
            Instructions.MVI_2e(cpu, memory);
            Assert.AreEqual(byte.MaxValue - 30, cpu.L);
            Assert.AreEqual<ushort>(6, cpu.PC);

            Assert.AreEqual<byte>(0, memory.ReadByte(cpu.HL));
            memory.WriteByte(cpu.PC, byte.MaxValue - 3);
            Instructions.MVI_36(cpu, memory);
            Assert.AreEqual(byte.MaxValue - 3, memory.ReadByte(cpu.HL));
            Assert.AreEqual<ushort>(7, cpu.PC);

            Assert.AreEqual<byte>(0, cpu.A);
            memory.WriteByte(cpu.PC, byte.MaxValue - 40);
            Instructions.MVI_3e(cpu, memory);
            Assert.AreEqual(byte.MaxValue - 40, cpu.A);
            Assert.AreEqual<ushort>(8, cpu.PC);
        }

        [TestMethod]
        public void TestMOVs()
        {
            Memory memory = new Memory();
            CPU cpu = new CPU();
            TestCPU.ResetCPU(cpu);

            cpu.A = 10;
            cpu.B = 20;
            cpu.C = 30;
            cpu.D = 40;
            cpu.E = 50;
            cpu.H = 60;
            cpu.L = 70;
            memory.WriteByte(cpu.HL, 100);

            Assert.AreEqual<byte>(20, cpu.B);
            Instructions.MOV_40(cpu, memory);
            Assert.AreEqual<byte>(20, cpu.B);
            Instructions.MOV_41(cpu, memory);
            Assert.AreEqual<byte>(30, cpu.B);
            Instructions.MOV_42(cpu, memory);
            Assert.AreEqual<byte>(40, cpu.B);
            Instructions.MOV_43(cpu, memory);
            Assert.AreEqual<byte>(50, cpu.B);
            Instructions.MOV_44(cpu, memory);
            Assert.AreEqual<byte>(60, cpu.B);
            Instructions.MOV_45(cpu, memory);
            Assert.AreEqual<byte>(70, cpu.B);
            Instructions.MOV_46(cpu, memory);
            Assert.AreEqual<byte>(100, cpu.B);
            Instructions.MOV_47(cpu, memory);
            Assert.AreEqual<byte>(10, cpu.B);

            cpu.B = 20;

            Assert.AreEqual<byte>(30, cpu.C);
            Instructions.MOV_48(cpu, memory);
            Assert.AreEqual<byte>(20, cpu.C);
            Instructions.MOV_49(cpu, memory);
            Assert.AreEqual<byte>(20, cpu.C);
            Instructions.MOV_4a(cpu, memory);
            Assert.AreEqual<byte>(40, cpu.C);
            Instructions.MOV_4b(cpu, memory);
            Assert.AreEqual<byte>(50, cpu.C);
            Instructions.MOV_4c(cpu, memory);
            Assert.AreEqual<byte>(60, cpu.C);
            Instructions.MOV_4d(cpu, memory);
            Assert.AreEqual<byte>(70, cpu.C);
            Instructions.MOV_4e(cpu, memory);
            Assert.AreEqual<byte>(100, cpu.C);
            Instructions.MOV_4f(cpu, memory);
            Assert.AreEqual<byte>(10, cpu.C);

            cpu.C = 30;

            Assert.AreEqual<byte>(40, cpu.D);
            Instructions.MOV_50(cpu, memory);
            Assert.AreEqual<byte>(20, cpu.D);
            Instructions.MOV_51(cpu, memory);
            Assert.AreEqual<byte>(30, cpu.D);
            Instructions.MOV_52(cpu, memory);
            Assert.AreEqual<byte>(30, cpu.D);
            Instructions.MOV_53(cpu, memory);
            Assert.AreEqual<byte>(50, cpu.D);
            Instructions.MOV_54(cpu, memory);
            Assert.AreEqual<byte>(60, cpu.D);
            Instructions.MOV_55(cpu, memory);
            Assert.AreEqual<byte>(70, cpu.D);
            Instructions.MOV_56(cpu, memory);
            Assert.AreEqual<byte>(100, cpu.D);
            Instructions.MOV_57(cpu, memory);
            Assert.AreEqual<byte>(10, cpu.D);

            cpu.D = 40;

            Assert.AreEqual<byte>(50, cpu.E);
            Instructions.MOV_58(cpu, memory);
            Assert.AreEqual<byte>(20, cpu.E);
            Instructions.MOV_59(cpu, memory);
            Assert.AreEqual<byte>(30, cpu.E);
            Instructions.MOV_5a(cpu, memory);
            Assert.AreEqual<byte>(40, cpu.E);
            Instructions.MOV_5b(cpu, memory);
            Assert.AreEqual<byte>(40, cpu.E);
            Instructions.MOV_5c(cpu, memory);
            Assert.AreEqual<byte>(60, cpu.E);
            Instructions.MOV_5d(cpu, memory);
            Assert.AreEqual<byte>(70, cpu.E);
            Instructions.MOV_5e(cpu, memory);
            Assert.AreEqual<byte>(100, cpu.E);
            Instructions.MOV_5f(cpu, memory);
            Assert.AreEqual<byte>(10, cpu.E);

            cpu.E = 50;

            Assert.AreEqual<byte>(60, cpu.H);
            Instructions.MOV_60(cpu, memory);
            Assert.AreEqual<byte>(20, cpu.H);
            Instructions.MOV_61(cpu, memory);
            Assert.AreEqual<byte>(30, cpu.H);
            Instructions.MOV_62(cpu, memory);
            Assert.AreEqual<byte>(40, cpu.H);
            Instructions.MOV_63(cpu, memory);
            Assert.AreEqual<byte>(50, cpu.H);
            Instructions.MOV_64(cpu, memory);
            Assert.AreEqual<byte>(50, cpu.H);
            Instructions.MOV_65(cpu, memory);
            Assert.AreEqual<byte>(70, cpu.H);
            cpu.H = 60;
            Instructions.MOV_66(cpu, memory);
            Assert.AreEqual<byte>(100, cpu.H);
            Instructions.MOV_67(cpu, memory);
            Assert.AreEqual<byte>(10, cpu.H);

            cpu.H = 60;

            Assert.AreEqual<byte>(70, cpu.L);
            Instructions.MOV_68(cpu, memory);
            Assert.AreEqual<byte>(20, cpu.L);
            Instructions.MOV_69(cpu, memory);
            Assert.AreEqual<byte>(30, cpu.L);
            Instructions.MOV_6a(cpu, memory);
            Assert.AreEqual<byte>(40, cpu.L);
            Instructions.MOV_6b(cpu, memory);
            Assert.AreEqual<byte>(50, cpu.L);
            Instructions.MOV_6c(cpu, memory);
            Assert.AreEqual<byte>(60, cpu.L);
            Instructions.MOV_6d(cpu, memory);
            Assert.AreEqual<byte>(60, cpu.L);
            cpu.L = 70;
            Instructions.MOV_6e(cpu, memory);
            Assert.AreEqual<byte>(100, cpu.L);
            Instructions.MOV_6f(cpu, memory);
            Assert.AreEqual<byte>(10, cpu.L);

            cpu.L = 70;

            Assert.AreEqual<byte>(100, memory.ReadByte(cpu.HL));
            Instructions.MOV_70(cpu, memory);
            Assert.AreEqual<byte>(20, memory.ReadByte(cpu.HL));
            Instructions.MOV_71(cpu, memory);
            Assert.AreEqual<byte>(30, memory.ReadByte(cpu.HL));
            Instructions.MOV_72(cpu, memory);
            Assert.AreEqual<byte>(40, memory.ReadByte(cpu.HL));
            Instructions.MOV_73(cpu, memory);
            Assert.AreEqual<byte>(50, memory.ReadByte(cpu.HL));
            Instructions.MOV_74(cpu, memory);
            Assert.AreEqual<byte>(60, memory.ReadByte(cpu.HL));
            Instructions.MOV_75(cpu, memory);
            Assert.AreEqual<byte>(70, memory.ReadByte(cpu.HL));
            Instructions.MOV_77(cpu, memory);
            Assert.AreEqual<byte>(10, memory.ReadByte(cpu.HL));

            memory.WriteByte(cpu.HL, 100);

            Assert.AreEqual<byte>(10, cpu.A);
            Instructions.MOV_78(cpu, memory);
            Assert.AreEqual<byte>(20, cpu.A);
            Instructions.MOV_79(cpu, memory);
            Assert.AreEqual<byte>(30, cpu.A);
            Instructions.MOV_7a(cpu, memory);
            Assert.AreEqual<byte>(40, cpu.A);
            Instructions.MOV_7b(cpu, memory);
            Assert.AreEqual<byte>(50, cpu.A);
            Instructions.MOV_7c(cpu, memory);
            Assert.AreEqual<byte>(60, cpu.A);
            Instructions.MOV_7d(cpu, memory);
            Assert.AreEqual<byte>(70, cpu.A);
            Instructions.MOV_7e(cpu, memory);
            Assert.AreEqual<byte>(100, cpu.A);
            Instructions.MOV_7f(cpu, memory);
            Assert.AreEqual<byte>(100, cpu.A);
        }

        [TestMethod]
        public void TestSTAX()
        {
            Memory memory = new Memory();
            CPU cpu = new CPU();
            TestCPU.ResetCPU(cpu);

            cpu.A = 10;
            cpu.BC = 200;
            cpu.DE = 400;

            Assert.AreEqual<byte>(0, memory.ReadByte(cpu.BC));
            Instructions.STAX_02(cpu, memory);
            Assert.AreEqual<byte>(10, memory.ReadByte(cpu.BC));
            Assert.AreEqual<byte>(0, memory.ReadByte(cpu.DE));
            Instructions.STAX_12(cpu, memory);
            Assert.AreEqual<byte>(10, memory.ReadByte(cpu.DE));

            memory.WriteWord(cpu.PC, 0x100);
            cpu.A = 10;
            Instructions.STA_32(cpu, memory);
            Assert.AreEqual<byte>(10, memory.ReadByte(0x100));
        }

        [TestMethod]
        public void TestLDAX()
        {
            Memory memory = new Memory();
            CPU cpu = new CPU();
            TestCPU.ResetCPU(cpu);

            cpu.A = 0;
            cpu.BC = 200;
            memory.WriteByte(cpu.BC, 10);
            cpu.DE = 400;
            memory.WriteByte(cpu.DE, 20);

            Assert.AreEqual<byte>(0, cpu.A);
            Instructions.LDAX_0a(cpu, memory);
            Assert.AreEqual<byte>(10, cpu.A);
            Instructions.LDAX_1a(cpu, memory);
            Assert.AreEqual<byte>(20, cpu.A);

            memory.WriteWord(cpu.PC, 0x100);
            memory.WriteByte(0x100, 10);
            Instructions.LDA_3a(cpu, memory);
            Assert.AreEqual<byte>(10, cpu.A);
        }
    }
}
