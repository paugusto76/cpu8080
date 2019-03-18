using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VM8080;

namespace VCPU8080Test
{
    [TestClass]
    public class TestCPU
    {
        internal static void ResetCPU(CPU cpu)
        {
            cpu.A = 0;
            cpu.B = 0;
            cpu.C = 0;
            cpu.D = 0;
            cpu.E = 0;
            cpu.H = 0;
            cpu.L = 0;
            cpu.Flags = 0;
            cpu.PC = 0;
            cpu.SP = 0;
        }

        [TestMethod]
        public void TestCPURegisterA()
        {
            CPU cpu = new CPU();
            ResetCPU(cpu);

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

            cpu.A = 1;
            Assert.AreEqual<byte>(1, cpu.A);
            Assert.AreEqual<ushort>(258, cpu.PSW);

            Assert.AreEqual<byte>(0, cpu.B);
            Assert.AreEqual<byte>(0, cpu.C);
            Assert.AreEqual<byte>(0, cpu.D);
            Assert.AreEqual<byte>(0, cpu.E);
            Assert.AreEqual<byte>(0, cpu.H);
            Assert.AreEqual<byte>(0, cpu.L);
            Assert.AreEqual<byte>(2, cpu.Flags);
            Assert.AreEqual<ushort>(0, cpu.SP);
            Assert.AreEqual<ushort>(0, cpu.PC);
        }

        [TestMethod]
        public void TestCPURegisterFlags()
        {
            CPU cpu = new CPU();
            ResetCPU(cpu);

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

            cpu.Flags = 1;
            Assert.AreEqual<byte>(3, cpu.Flags);
            Assert.AreEqual<ushort>(3, cpu.PSW);
            cpu.PSW = 256;
            Assert.AreEqual<byte>(2, cpu.Flags);
            Assert.AreEqual<byte>(1, cpu.A);
            cpu.PSW = 1;
            Assert.AreEqual<byte>(3, cpu.Flags);


            Assert.AreEqual<byte>(0, cpu.A);
            Assert.AreEqual<byte>(0, cpu.B);
            Assert.AreEqual<byte>(0, cpu.C);
            Assert.AreEqual<byte>(0, cpu.D);
            Assert.AreEqual<byte>(0, cpu.E);
            Assert.AreEqual<byte>(0, cpu.H);
            Assert.AreEqual<byte>(0, cpu.L);
            Assert.AreEqual<ushort>(0, cpu.SP);
            Assert.AreEqual<ushort>(0, cpu.PC);
        }

        [TestMethod]
        public void TestCPURegisterB()
        {
            CPU cpu = new CPU();
            ResetCPU(cpu);

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

            cpu.B = 1;
            Assert.AreEqual<byte>(1, cpu.B);
            Assert.AreEqual<ushort>(256, cpu.BC);

            Assert.AreEqual<byte>(0, cpu.A);
            Assert.AreEqual<byte>(0, cpu.C);
            Assert.AreEqual<byte>(0, cpu.D);
            Assert.AreEqual<byte>(0, cpu.E);
            Assert.AreEqual<byte>(0, cpu.H);
            Assert.AreEqual<byte>(0, cpu.L);
            Assert.AreEqual<byte>(2, cpu.Flags);
            Assert.AreEqual<ushort>(0, cpu.SP);
            Assert.AreEqual<ushort>(0, cpu.PC);
        }

        [TestMethod]
        public void TestCPURegisterC()
        {
            CPU cpu = new CPU();
            ResetCPU(cpu);

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

            cpu.C = 1;
            Assert.AreEqual<byte>(1, cpu.C);
            Assert.AreEqual<ushort>(1, cpu.BC);
            cpu.BC = 256;
            Assert.AreEqual<byte>(0, cpu.C);
            Assert.AreEqual<byte>(1, cpu.B);
            cpu.BC = 1;
            Assert.AreEqual<byte>(1, cpu.C);

            Assert.AreEqual<byte>(0, cpu.A);
            Assert.AreEqual<byte>(0, cpu.B);
            Assert.AreEqual<byte>(0, cpu.D);
            Assert.AreEqual<byte>(0, cpu.E);
            Assert.AreEqual<byte>(0, cpu.H);
            Assert.AreEqual<byte>(0, cpu.L);
            Assert.AreEqual<byte>(2, cpu.Flags);
            Assert.AreEqual<ushort>(0, cpu.SP);
            Assert.AreEqual<ushort>(0, cpu.PC);
        }

        [TestMethod]
        public void TestCPURegisterD()
        {
            CPU cpu = new CPU();
            ResetCPU(cpu);

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

            cpu.D = 1;
            Assert.AreEqual<byte>(1, cpu.D);
            Assert.AreEqual<ushort>(256, cpu.DE);

            Assert.AreEqual<byte>(0, cpu.A);
            Assert.AreEqual<byte>(0, cpu.B);
            Assert.AreEqual<byte>(0, cpu.C);
            Assert.AreEqual<byte>(0, cpu.E);
            Assert.AreEqual<byte>(0, cpu.H);
            Assert.AreEqual<byte>(0, cpu.L);
            Assert.AreEqual<byte>(2, cpu.Flags);
            Assert.AreEqual<ushort>(0, cpu.SP);
            Assert.AreEqual<ushort>(0, cpu.PC);
        }

        [TestMethod]
        public void TestCPURegisterE()
        {
            CPU cpu = new CPU();
            ResetCPU(cpu);

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

            cpu.E = 1;
            Assert.AreEqual<byte>(1, cpu.E);
            Assert.AreEqual<ushort>(1, cpu.DE);
            cpu.DE = 256;
            Assert.AreEqual<byte>(0, cpu.E);
            Assert.AreEqual<byte>(1, cpu.D);
            cpu.DE = 1;
            Assert.AreEqual<byte>(1, cpu.E);

            Assert.AreEqual<byte>(0, cpu.A);
            Assert.AreEqual<byte>(0, cpu.B);
            Assert.AreEqual<byte>(0, cpu.C);
            Assert.AreEqual<byte>(0, cpu.D);
            Assert.AreEqual<byte>(0, cpu.H);
            Assert.AreEqual<byte>(0, cpu.L);
            Assert.AreEqual<byte>(2, cpu.Flags);
            Assert.AreEqual<ushort>(0, cpu.SP);
            Assert.AreEqual<ushort>(0, cpu.PC);
        }

        [TestMethod]
        public void TestCPURegisterH()
        {
            CPU cpu = new CPU();
            ResetCPU(cpu);

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

            cpu.H = 1;
            Assert.AreEqual<byte>(1, cpu.H);
            Assert.AreEqual<ushort>(256, cpu.HL);

            Assert.AreEqual<byte>(0, cpu.A);
            Assert.AreEqual<byte>(0, cpu.B);
            Assert.AreEqual<byte>(0, cpu.C);
            Assert.AreEqual<byte>(0, cpu.D);
            Assert.AreEqual<byte>(0, cpu.E);
            Assert.AreEqual<byte>(0, cpu.L);
            Assert.AreEqual<byte>(2, cpu.Flags);
            Assert.AreEqual<ushort>(0, cpu.SP);
            Assert.AreEqual<ushort>(0, cpu.PC);
        }

        [TestMethod]
        public void TestCPURegisterL()
        {
            CPU cpu = new CPU();
            ResetCPU(cpu);

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

            cpu.L = 1;
            Assert.AreEqual<byte>(1, cpu.L);
            Assert.AreEqual<ushort>(1, cpu.HL);
            cpu.HL = 256;
            Assert.AreEqual<byte>(0, cpu.L);
            Assert.AreEqual<byte>(1, cpu.H);
            cpu.HL = 1;
            Assert.AreEqual<byte>(1, cpu.L);


            Assert.AreEqual<byte>(0, cpu.A);
            Assert.AreEqual<byte>(0, cpu.B);
            Assert.AreEqual<byte>(0, cpu.C);
            Assert.AreEqual<byte>(0, cpu.D);
            Assert.AreEqual<byte>(0, cpu.E);
            Assert.AreEqual<byte>(0, cpu.H);
            Assert.AreEqual<byte>(2, cpu.Flags);
            Assert.AreEqual<ushort>(0, cpu.SP);
            Assert.AreEqual<ushort>(0, cpu.PC);
        }

        [TestMethod]
        public void TestCPURegisterSP()
        {
            CPU cpu = new CPU();
            ResetCPU(cpu);

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

            cpu.SP = 1;
            Assert.AreEqual<ushort>(1, cpu.SP);

            Assert.AreEqual<byte>(0, cpu.A);
            Assert.AreEqual<byte>(0, cpu.B);
            Assert.AreEqual<byte>(0, cpu.C);
            Assert.AreEqual<byte>(0, cpu.D);
            Assert.AreEqual<byte>(0, cpu.E);
            Assert.AreEqual<byte>(0, cpu.H);
            Assert.AreEqual<byte>(0, cpu.L);
            Assert.AreEqual<byte>(2, cpu.Flags);
            Assert.AreEqual<ushort>(0, cpu.PC);
        }

        [TestMethod]
        public void TestCPURegisterPC()
        {
            CPU cpu = new CPU();
            ResetCPU(cpu);

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

            cpu.PC = 1;
            Assert.AreEqual<ushort>(1, cpu.PC);

            Assert.AreEqual<byte>(0, cpu.A);
            Assert.AreEqual<byte>(0, cpu.B);
            Assert.AreEqual<byte>(0, cpu.C);
            Assert.AreEqual<byte>(0, cpu.D);
            Assert.AreEqual<byte>(0, cpu.E);
            Assert.AreEqual<byte>(0, cpu.H);
            Assert.AreEqual<byte>(0, cpu.L);
            Assert.AreEqual<byte>(2, cpu.Flags);
            Assert.AreEqual<ushort>(0, cpu.SP);
        }

        [TestMethod]
        public void TestCPUFlags()
        {
            CPU cpu = new CPU();
            ResetCPU(cpu);

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

            cpu.FlagCarry = true;
            Assert.AreEqual(true, cpu.FlagCarry);
            Assert.AreEqual<byte>(0x03, cpu.Flags);
            Assert.AreEqual<byte>(0, cpu.A);
            Assert.AreEqual<ushort>(0x03, cpu.PSW);
            cpu.FlagCarry = false;
            Assert.AreEqual(false, cpu.FlagCarry);

            cpu.FlagParity = true;
            Assert.AreEqual(true, cpu.FlagParity);
            Assert.AreEqual<byte>(0x06, cpu.Flags);
            Assert.AreEqual<byte>(0, cpu.A);
            Assert.AreEqual<ushort>(0x06, cpu.PSW);
            cpu.FlagParity = false;
            Assert.AreEqual(false, cpu.FlagParity);

            cpu.FlagAuxCarry = true;
            Assert.AreEqual(true, cpu.FlagAuxCarry);
            Assert.AreEqual<byte>(0x12, cpu.Flags);
            Assert.AreEqual<byte>(0, cpu.A);
            Assert.AreEqual<ushort>(0x12, cpu.PSW);
            cpu.FlagAuxCarry = false;
            Assert.AreEqual(false, cpu.FlagAuxCarry);

            cpu.FlagZero = true;
            Assert.AreEqual(true, cpu.FlagZero);
            Assert.AreEqual<byte>(0x42, cpu.Flags);
            Assert.AreEqual<byte>(0, cpu.A);
            Assert.AreEqual<ushort>(0x42, cpu.PSW);
            cpu.FlagZero = false;
            Assert.AreEqual(false, cpu.FlagZero);

            cpu.FlagSign = true;
            Assert.AreEqual(true, cpu.FlagSign);
            Assert.AreEqual<byte>(0x82, cpu.Flags);
            Assert.AreEqual<byte>(0, cpu.A);
            Assert.AreEqual<ushort>(0x82, cpu.PSW);
            cpu.FlagSign = false;
            Assert.AreEqual(false, cpu.FlagSign);

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
        }
    }
}
