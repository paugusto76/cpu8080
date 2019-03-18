using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VM8080
{
    public class Instructions
    {
        private const int cycleStep = 10;
        private static DateTime _target = DateTime.MaxValue;

        private static void SetTarget(int cycles)
        {
            _target = DateTime.Now.AddMilliseconds(cycles * cycleStep);
        }

        private static void WaitForTarget()
        {
            while ((_target - DateTime.Now).TotalMilliseconds > 0)
            { }
        }

        public static void NOP_00(CPU cpu, Memory memory)
        {
            int cycles = 4;
            SetTarget(cycles);

            cpu.AddOpcode(0x00);
            cpu.AddInstructionString("NOP");

            WaitForTarget();
        }

        public static void STAX_02(CPU cpu, Memory memory)
        {
            int cycles = 7;
            SetTarget(cycles);

            cpu.AddOpcode(0x02);
            cpu.AddInstructionString("STAX B");

            memory.WriteByte(cpu.BC, cpu.A);

            WaitForTarget();
        }

        public static void MVI_06(CPU cpu, Memory memory)
        {
            int cycles = 7;
            SetTarget(cycles);
            byte immediate = memory.ReadByte(cpu.PC);

            cpu.AddOpcode(0x06);
            cpu.AddBufferData(immediate);
            cpu.AddInstructionString("MVI B,d8");

            cpu.PC++;
            cpu.B = immediate;

            WaitForTarget();
        }

        public static void NOP_08(CPU cpu, Memory memory)
        {
            int cycles = 4;
            SetTarget(cycles);
            int opcode = 0x08;

            Debug.Print($"Processed Instruction NOP ({opcode.ToString("X2")})");

            WaitForTarget();
            
        }

        public static void LDAX_0a(CPU cpu, Memory memory)
        {
            int cycles = 7;
            SetTarget(cycles);
            int opcode = 0x0a;

            cpu.A = memory.ReadByte(cpu.BC);

            Debug.Print($"Processed Instruction LDAX B ({opcode.ToString("X2")})");

            WaitForTarget();
            
        }

        public static void MVI_0e(CPU cpu, Memory memory)
        {
            int cycles = 7;
            SetTarget(cycles);
            int opcode = 0x0e;

            byte immediate = memory.ReadByte(cpu.PC);

            cpu.PC++;
            cpu.C = immediate;

            Debug.Print($"Processed Instruction MVI C,d8 ({opcode.ToString("X2")} {immediate.ToString("X2")})");

            WaitForTarget();
            
        }

        public static void NOP_10(CPU cpu, Memory memory)
        {
            int cycles = 4;
            SetTarget(cycles);
            int opcode = 0x10;

            Debug.Print($"Processed Instruction NOP ({opcode.ToString("X2")})");

            WaitForTarget();
            
        }

        public static void STAX_12(CPU cpu, Memory memory)
        {
            int cycles = 7;
            SetTarget(cycles);
            int opcode = 0x12;

            memory.WriteByte(cpu.DE, cpu.A);

            Debug.Print($"Processed Instruction STAX D ({opcode.ToString("X2")})");

            WaitForTarget();
            
        }

        public static void MVI_16(CPU cpu, Memory memory)
        {
            int cycles = 7;
            SetTarget(cycles);
            int opcode = 0x16;

            byte immediate = memory.ReadByte(cpu.PC);

            cpu.PC++;
            cpu.D = immediate;

            Debug.Print($"Processed Instruction MVI D,d8 ({opcode.ToString("X2")} {immediate.ToString("X2")})");

            WaitForTarget();
            
        }

        public static void NOP_18(CPU cpu, Memory memory)
        {
            int cycles = 4;
            SetTarget(cycles);
            int opcode = 0x18;

            Debug.Print($"Processed Instruction NOP ({opcode.ToString("X2")})");

            WaitForTarget();
            
        }

        public static void LDAX_1a(CPU cpu, Memory memory)
        {
            int cycles = 7;
            SetTarget(cycles);
            int opcode = 0x1a;

            cpu.A = memory.ReadByte(cpu.DE);

            Debug.Print($"Processed Instruction LDAX D ({opcode.ToString("X2")})");

            WaitForTarget();
            
        }

        public static void MVI_1e(CPU cpu, Memory memory)
        {
            int cycles = 7;
            SetTarget(cycles);
            int opcode = 0x1e;

            byte immediate = memory.ReadByte(cpu.PC);

            cpu.PC++;
            cpu.E = immediate;

            Debug.Print($"Processed Instruction MVI E,d8 ({opcode.ToString("X2")} {immediate.ToString("X2")})");

            WaitForTarget();
            
        }

        public static void NOP_20(CPU cpu, Memory memory)
        {
            int cycles = 4;
            SetTarget(cycles);
            int opcode = 0x20;

            Debug.Print($"Processed Instruction NOP ({opcode.ToString("X2")})");

            WaitForTarget();
            
        }

        public static void MVI_26(CPU cpu, Memory memory)
        {
            int cycles = 7;
            SetTarget(cycles);
            int opcode = 0x26;

            byte immediate = memory.ReadByte(cpu.PC);

            cpu.PC++;
            cpu.H = immediate;

            Debug.Print($"Processed Instruction MVI H,d8 ({opcode.ToString("X2")} {immediate.ToString("X2")})");

            WaitForTarget();
            
        }

        public static void NOP_28(CPU cpu, Memory memory)
        {
            int cycles = 4;
            SetTarget(cycles);
            int opcode = 0x28;

            Debug.Print($"Processed Instruction NOP ({opcode.ToString("X2")})");

            WaitForTarget();
            
        }

        public static void MVI_2e(CPU cpu, Memory memory)
        {
            int cycles = 7;
            SetTarget(cycles);
            int opcode = 0x2e;

            byte immediate = memory.ReadByte(cpu.PC);

            cpu.PC++;
            cpu.L = immediate;

            Debug.Print($"Processed Instruction MVI L,d8 ({opcode.ToString("X2")} {immediate.ToString("X2")})");

            WaitForTarget();
            
        }

        public static void NOP_30(CPU cpu, Memory memory)
        {
            int cycles = 4;
            SetTarget(cycles);
            int opcode = 0x30;

            Debug.Print($"Processed Instruction NOP ({opcode.ToString("X2")})");

            WaitForTarget();
            
        }

        public static void STA_32(CPU cpu, Memory memory)
        {
            int cycles = 13;
            SetTarget(cycles);
            int opcode = 0x32;

            ushort address = memory.ReadWord(cpu.PC);
            cpu.PC += 2;

            memory.WriteByte(address, cpu.A);

            Debug.Print($"Processed Instruction STA a16 ({opcode.ToString("X2")})");

            WaitForTarget();
            
        }

        public static void MVI_36(CPU cpu, Memory memory)
        {
            int cycles = 10;
            SetTarget(cycles);
            int opcode = 0x36;

            byte immediate = memory.ReadByte(cpu.PC);

            cpu.PC++;

            memory.WriteByte(cpu.HL, immediate);

            Debug.Print($"Processed Instruction MVI M,d8 ({opcode.ToString("X2")} {immediate.ToString("X2")})");

            WaitForTarget();
            
        }

        public static void NOP_38(CPU cpu, Memory memory)
        {
            int cycles = 4;
            SetTarget(cycles);
            int opcode = 0x38;

            Debug.Print($"Processed Instruction NOP ({opcode.ToString("X2")})");

            WaitForTarget();
            
        }

        public static void LDA_3a(CPU cpu, Memory memory)
        {
            int cycles = 13;
            SetTarget(cycles);
            int opcode = 0x32;

            ushort address = memory.ReadWord(cpu.PC);
            cpu.PC += 2;

            cpu.A = memory.ReadByte(address);

            Debug.Print($"Processed Instruction LDA a16 ({opcode.ToString("X2")})");

            WaitForTarget();
            
        }

        public static void MVI_3e(CPU cpu, Memory memory)
        {
            int cycles = 7;
            SetTarget(cycles);
            int opcode = 0x3e;

            byte immediate = memory.ReadByte(cpu.PC);

            cpu.PC++;
            cpu.A = immediate;

            Debug.Print($"Processed Instruction MVI A,d8 ({opcode.ToString("X2")} {immediate.ToString("X2")})");

            WaitForTarget();
            
        }

        public static void MOV_40(CPU cpu, Memory memory)
        {
            int cycles = 5;
            SetTarget(cycles);
            int opcode = 0x40;

            cpu.B = cpu.B;

            Debug.Print($"Processed Instruction MOV B,B ({opcode.ToString("X2")})");

            WaitForTarget();
            
        }

        public static void MOV_41(CPU cpu, Memory memory)
        {
            int cycles = 5;
            SetTarget(cycles);
            int opcode = 0x41;

            cpu.B = cpu.C;

            Debug.Print($"Processed Instruction MOV B,C ({opcode.ToString("X2")})");

            WaitForTarget();
            
        }

        public static void MOV_42(CPU cpu, Memory memory)
        {
            int cycles = 5;
            SetTarget(cycles);
            int opcode = 0x42;

            cpu.B = cpu.D;

            Debug.Print($"Processed Instruction MOV B,D ({opcode.ToString("X2")})");

            WaitForTarget();
            
        }

        public static void MOV_43(CPU cpu, Memory memory)
        {
            int cycles = 5;
            SetTarget(cycles);
            int opcode = 0x43;

            cpu.B = cpu.E;

            Debug.Print($"Processed Instruction MOV B,E ({opcode.ToString("X2")})");

            WaitForTarget();
            
        }

        public static void MOV_44(CPU cpu, Memory memory)
        {
            int cycles = 5;
            SetTarget(cycles);
            int opcode = 0x44;

            cpu.B = cpu.H;

            Debug.Print($"Processed Instruction MOV B,H ({opcode.ToString("X2")})");

            WaitForTarget();
            
        }

        public static void MOV_45(CPU cpu, Memory memory)
        {
            int cycles = 5;
            SetTarget(cycles);
            int opcode = 0x45;

            cpu.B = cpu.L;

            Debug.Print($"Processed Instruction MOV B,L ({opcode.ToString("X2")})");

            WaitForTarget();
            
        }

        public static void MOV_46(CPU cpu, Memory memory)
        {
            int cycles = 7;
            SetTarget(cycles);
            int opcode = 0x46;

            cpu.B = memory.ReadByte(cpu.HL);

            Debug.Print($"Processed Instruction MOV B,M ({opcode.ToString("X2")})");

            WaitForTarget();
            
        }

        public static void MOV_47(CPU cpu, Memory memory)
        {
            int cycles = 5;
            SetTarget(cycles);
            int opcode = 0x47;

            cpu.B = cpu.A;

            Debug.Print($"Processed Instruction MOV B,A ({opcode.ToString("X2")})");

            WaitForTarget();
            
        }

        public static void MOV_48(CPU cpu, Memory memory)
        {
            int cycles = 5;
            SetTarget(cycles);
            int opcode = 0x48;

            cpu.C = cpu.B;

            Debug.Print($"Processed Instruction MOV C,B ({opcode.ToString("X2")})");

            WaitForTarget();
            
        }

        public static void MOV_49(CPU cpu, Memory memory)
        {
            int cycles = 5;
            SetTarget(cycles);
            int opcode = 0x49;

            cpu.C = cpu.C;

            Debug.Print($"Processed Instruction MOV C,C ({opcode.ToString("X2")})");

            WaitForTarget();
            
        }

        public static void MOV_4a(CPU cpu, Memory memory)
        {
            int cycles = 5;
            SetTarget(cycles);
            int opcode = 0x4a;

            cpu.C = cpu.D;

            Debug.Print($"Processed Instruction MOV C,D ({opcode.ToString("X2")})");

            WaitForTarget();
            
        }

        public static void MOV_4b(CPU cpu, Memory memory)
        {
            int cycles = 5;
            SetTarget(cycles);
            int opcode = 0x4b;

            cpu.C = cpu.E;

            Debug.Print($"Processed Instruction MOV C,E ({opcode.ToString("X2")})");

            WaitForTarget();
            
        }

        public static void MOV_4c(CPU cpu, Memory memory)
        {
            int cycles = 5;
            SetTarget(cycles);
            int opcode = 0x4c;

            cpu.C = cpu.H;

            Debug.Print($"Processed Instruction MOV C,H ({opcode.ToString("X2")})");

            WaitForTarget();
            
        }

        public static void MOV_4d(CPU cpu, Memory memory)
        {
            int cycles = 5;
            SetTarget(cycles);
            int opcode = 0x4d;

            cpu.C = cpu.L;

            Debug.Print($"Processed Instruction MOV C,L ({opcode.ToString("X2")})");

            WaitForTarget();
            
        }

        public static void MOV_4e(CPU cpu, Memory memory)
        {
            int cycles = 7;
            SetTarget(cycles);
            int opcode = 0x4e;

            cpu.C = memory.ReadByte(cpu.HL);

            Debug.Print($"Processed Instruction MOV C,M ({opcode.ToString("X2")})");

            WaitForTarget();
            
        }

        public static void MOV_4f(CPU cpu, Memory memory)
        {
            int cycles = 5;
            SetTarget(cycles);
            int opcode = 0x4f;

            cpu.C = cpu.A;

            Debug.Print($"Processed Instruction MOV C,A ({opcode.ToString("X2")})");

            WaitForTarget();
            
        }

        public static void MOV_50(CPU cpu, Memory memory)
        {
            int cycles = 5;
            SetTarget(cycles);
            int opcode = 0x50;

            cpu.D = cpu.B;

            Debug.Print($"Processed Instruction MOV D,B ({opcode.ToString("X2")})");

            WaitForTarget();
            
        }

        public static void MOV_51(CPU cpu, Memory memory)
        {
            int cycles = 5;
            SetTarget(cycles);
            int opcode = 0x51;

            cpu.D = cpu.C;

            Debug.Print($"Processed Instruction MOV D,C ({opcode.ToString("X2")})");

            WaitForTarget();
            
        }

        public static void MOV_52(CPU cpu, Memory memory)
        {
            int cycles = 5;
            SetTarget(cycles);
            int opcode = 0x52;

            cpu.D = cpu.D;

            Debug.Print($"Processed Instruction MOV D,D ({opcode.ToString("X2")})");

            WaitForTarget();
            
        }

        public static void MOV_53(CPU cpu, Memory memory)
        {
            int cycles = 5;
            SetTarget(cycles);
            int opcode = 0x53;

            cpu.D = cpu.E;

            Debug.Print($"Processed Instruction MOV D,E ({opcode.ToString("X2")})");

            WaitForTarget();
            
        }

        public static void MOV_54(CPU cpu, Memory memory)
        {
            int cycles = 5;
            SetTarget(cycles);
            int opcode = 0x54;

            cpu.D = cpu.H;

            Debug.Print($"Processed Instruction MOV D,H ({opcode.ToString("X2")})");

            WaitForTarget();
            
        }

        public static void MOV_55(CPU cpu, Memory memory)
        {
            int cycles = 5;
            SetTarget(cycles);
            int opcode = 0x55;

            cpu.D = cpu.L;

            Debug.Print($"Processed Instruction MOV D,L ({opcode.ToString("X2")})");

            WaitForTarget();
            
        }

        public static void MOV_56(CPU cpu, Memory memory)
        {
            int cycles = 7;
            SetTarget(cycles);
            int opcode = 0x56;

            cpu.D = memory.ReadByte(cpu.HL);

            Debug.Print($"Processed Instruction MOV D,M ({opcode.ToString("X2")})");

            WaitForTarget();
            
        }

        public static void MOV_57(CPU cpu, Memory memory)
        {
            int cycles = 5;
            SetTarget(cycles);
            int opcode = 0x57;

            cpu.D = cpu.A;

            Debug.Print($"Processed Instruction MOV D,A ({opcode.ToString("X2")})");

            WaitForTarget();
            
        }

        public static void MOV_58(CPU cpu, Memory memory)
        {
            int cycles = 5;
            SetTarget(cycles);
            int opcode = 0x58;

            cpu.E = cpu.B;

            Debug.Print($"Processed Instruction MOV E,B ({opcode.ToString("X2")})");

            WaitForTarget();
            
        }

        public static void MOV_59(CPU cpu, Memory memory)
        {
            int cycles = 5;
            SetTarget(cycles);
            int opcode = 0x59;

            cpu.E = cpu.C;

            Debug.Print($"Processed Instruction MOV E,C ({opcode.ToString("X2")})");

            WaitForTarget();
            
        }

        public static void MOV_5a(CPU cpu, Memory memory)
        {
            int cycles = 5;
            SetTarget(cycles);
            int opcode = 0x5a;

            cpu.E = cpu.D;

            Debug.Print($"Processed Instruction MOV E,D ({opcode.ToString("X2")})");

            WaitForTarget();
            
        }

        public static void MOV_5b(CPU cpu, Memory memory)
        {
            int cycles = 5;
            SetTarget(cycles);
            int opcode = 0x5b;

            cpu.E = cpu.E;

            Debug.Print($"Processed Instruction MOV E,E ({opcode.ToString("X2")})");

            WaitForTarget();
            
        }

        public static void MOV_5c(CPU cpu, Memory memory)
        {
            int cycles = 5;
            SetTarget(cycles);
            int opcode = 0x5c;

            cpu.E = cpu.H;

            Debug.Print($"Processed Instruction MOV E,H ({opcode.ToString("X2")})");

            WaitForTarget();
            
        }

        public static void MOV_5d(CPU cpu, Memory memory)
        {
            int cycles = 5;
            SetTarget(cycles);
            int opcode = 0x5d;

            cpu.E = cpu.L;

            Debug.Print($"Processed Instruction MOV E,L ({opcode.ToString("X2")})");

            WaitForTarget();
            
        }

        public static void MOV_5e(CPU cpu, Memory memory)
        {
            int cycles = 7;
            SetTarget(cycles);
            int opcode = 0x5e;

            cpu.E = memory.ReadByte(cpu.HL);

            Debug.Print($"Processed Instruction MOV E,M ({opcode.ToString("X2")})");

            WaitForTarget();
            
        }

        public static void MOV_5f(CPU cpu, Memory memory)
        {
            int cycles = 5;
            SetTarget(cycles);
            int opcode = 0x5f;

            cpu.E = cpu.A;

            Debug.Print($"Processed Instruction MOV E,A ({opcode.ToString("X2")})");

            WaitForTarget();
            
        }

        public static void MOV_60(CPU cpu, Memory memory)
        {
            int cycles = 5;
            SetTarget(cycles);
            int opcode = 0x60;

            cpu.H = cpu.B;

            Debug.Print($"Processed Instruction MOV H,B ({opcode.ToString("X2")})");

            WaitForTarget();
            
        }

        public static void MOV_61(CPU cpu, Memory memory)
        {
            int cycles = 5;
            SetTarget(cycles);
            int opcode = 0x61;

            cpu.H = cpu.C;

            Debug.Print($"Processed Instruction MOV H,C ({opcode.ToString("X2")})");

            WaitForTarget();
            
        }

        public static void MOV_62(CPU cpu, Memory memory)
        {
            int cycles = 5;
            SetTarget(cycles);
            int opcode = 0x62;

            cpu.H = cpu.D;

            Debug.Print($"Processed Instruction MOV H,D ({opcode.ToString("X2")})");

            WaitForTarget();
            
        }

        public static void MOV_63(CPU cpu, Memory memory)
        {
            int cycles = 5;
            SetTarget(cycles);
            int opcode = 0x63;

            cpu.H = cpu.E;

            Debug.Print($"Processed Instruction MOV H,E ({opcode.ToString("X2")})");

            WaitForTarget();
            
        }

        public static void MOV_64(CPU cpu, Memory memory)
        {
            int cycles = 5;
            SetTarget(cycles);
            int opcode = 0x64;

            cpu.H = cpu.H;

            Debug.Print($"Processed Instruction MOV H,H ({opcode.ToString("X2")})");

            WaitForTarget();
            
        }

        public static void MOV_65(CPU cpu, Memory memory)
        {
            int cycles = 5;
            SetTarget(cycles);
            int opcode = 0x65;

            cpu.H = cpu.L;

            Debug.Print($"Processed Instruction MOV H,L ({opcode.ToString("X2")})");

            WaitForTarget();
            
        }

        public static void MOV_66(CPU cpu, Memory memory)
        {
            int cycles = 7;
            SetTarget(cycles);
            int opcode = 0x66;

            cpu.H = memory.ReadByte(cpu.HL);

            Debug.Print($"Processed Instruction MOV H,M ({opcode.ToString("X2")})");

            WaitForTarget();
            
        }

        public static void MOV_67(CPU cpu, Memory memory)
        {
            int cycles = 5;
            SetTarget(cycles);
            int opcode = 0x67;

            cpu.H = cpu.A;

            Debug.Print($"Processed Instruction MOV H,A ({opcode.ToString("X2")})");

            WaitForTarget();
            
        }

        public static void MOV_68(CPU cpu, Memory memory)
        {
            int cycles = 5;
            SetTarget(cycles);
            int opcode = 0x68;

            cpu.L = cpu.B;

            Debug.Print($"Processed Instruction MOV L,B ({opcode.ToString("X2")})");

            WaitForTarget();
            
        }

        public static void MOV_69(CPU cpu, Memory memory)
        {
            int cycles = 5;
            SetTarget(cycles);
            int opcode = 0x69;

            cpu.L = cpu.C;

            Debug.Print($"Processed Instruction MOV L,C ({opcode.ToString("X2")})");

            WaitForTarget();
            
        }

        public static void MOV_6a(CPU cpu, Memory memory)
        {
            int cycles = 5;
            SetTarget(cycles);
            int opcode = 0x6a;

            cpu.L = cpu.D;

            Debug.Print($"Processed Instruction MOV L,D ({opcode.ToString("X2")})");

            WaitForTarget();
            
        }

        public static void MOV_6b(CPU cpu, Memory memory)
        {
            int cycles = 5;
            SetTarget(cycles);
            int opcode = 0x6b;

            cpu.L = cpu.E;

            Debug.Print($"Processed Instruction MOV L,E ({opcode.ToString("X2")})");

            WaitForTarget();
            
        }

        public static void MOV_6c(CPU cpu, Memory memory)
        {
            int cycles = 5;
            SetTarget(cycles);
            int opcode = 0x6c;

            cpu.L = cpu.H;

            Debug.Print($"Processed Instruction MOV L,H ({opcode.ToString("X2")})");

            WaitForTarget();
            
        }

        public static void MOV_6d(CPU cpu, Memory memory)
        {
            int cycles = 5;
            SetTarget(cycles);
            int opcode = 0x6d;

            cpu.L = cpu.L;

            Debug.Print($"Processed Instruction MOV L,L ({opcode.ToString("X2")})");

            WaitForTarget();
            
        }

        public static void MOV_6e(CPU cpu, Memory memory)
        {
            int cycles = 7;
            SetTarget(cycles);
            int opcode = 0x6e;

            cpu.L = memory.ReadByte(cpu.HL);

            Debug.Print($"Processed Instruction MOV L,M ({opcode.ToString("X2")})");

            WaitForTarget();
            
        }

        public static void MOV_6f(CPU cpu, Memory memory)
        {
            int cycles = 5;
            SetTarget(cycles);
            int opcode = 0x6f;

            cpu.L = cpu.A;

            Debug.Print($"Processed Instruction MOV L,A ({opcode.ToString("X2")})");

            WaitForTarget();
            
        }

        public static void MOV_70(CPU cpu, Memory memory)
        {
            int cycles = 7;
            SetTarget(cycles);
            int opcode = 0x70;

            memory.WriteByte(cpu.HL, cpu.B);

            Debug.Print($"Processed Instruction MOV M,B ({opcode.ToString("X2")})");

            WaitForTarget();
            
        }

        public static void MOV_71(CPU cpu, Memory memory)
        {
            int cycles = 7;
            SetTarget(cycles);
            int opcode = 0x71;

            memory.WriteByte(cpu.HL, cpu.C);

            Debug.Print($"Processed Instruction MOV M,C ({opcode.ToString("X2")})");

            WaitForTarget();
            
        }

        public static void MOV_72(CPU cpu, Memory memory)
        {
            int cycles = 7;
            SetTarget(cycles);
            int opcode = 0x72;

            memory.WriteByte(cpu.HL, cpu.D);

            Debug.Print($"Processed Instruction MOV M,D ({opcode.ToString("X2")})");

            WaitForTarget();
            
        }

        public static void MOV_73(CPU cpu, Memory memory)
        {
            int cycles = 7;
            SetTarget(cycles);
            int opcode = 0x73;

            memory.WriteByte(cpu.HL, cpu.E);

            Debug.Print($"Processed Instruction MOV M,E ({opcode.ToString("X2")})");

            WaitForTarget();
            
        }

        public static void MOV_74(CPU cpu, Memory memory)
        {
            int cycles = 7;
            SetTarget(cycles);
            int opcode = 0x74;

            memory.WriteByte(cpu.HL, cpu.H);

            Debug.Print($"Processed Instruction MOV M,H ({opcode.ToString("X2")})");

            WaitForTarget();
            
        }

        public static void MOV_75(CPU cpu, Memory memory)
        {
            int cycles = 7;
            SetTarget(cycles);
            int opcode = 0x75;

            memory.WriteByte(cpu.HL, cpu.L);

            Debug.Print($"Processed Instruction MOV M,L ({opcode.ToString("X2")})");

            WaitForTarget();
            
        }

        public static void HLT_76(CPU cpu, Memory memory)
        {
            int cycles = 7;
            SetTarget(cycles);
            int opcode = 0x76;

            cpu.Halted = true;

            Debug.Print($"Processed Instruction HLT ({opcode.ToString("X2")})");

            WaitForTarget();
            
        }

        public static void MOV_77(CPU cpu, Memory memory)
        {
            int cycles = 7;
            SetTarget(cycles);
            int opcode = 0x77;

            memory.WriteByte(cpu.HL, cpu.A);

            Debug.Print($"Processed Instruction MOV M,A ({opcode.ToString("X2")})");

            WaitForTarget();
            
        }

        public static void MOV_78(CPU cpu, Memory memory)
        {
            int cycles = 5;
            SetTarget(cycles);
            int opcode = 0x78;

            cpu.A = cpu.B;

            Debug.Print($"Processed Instruction MOV A,B ({opcode.ToString("X2")})");

            WaitForTarget();
            
        }

        public static void MOV_79(CPU cpu, Memory memory)
        {
            int cycles = 5;
            SetTarget(cycles);
            int opcode = 0x79;

            cpu.A = cpu.C;

            Debug.Print($"Processed Instruction MOV A,C ({opcode.ToString("X2")})");

            WaitForTarget();
            
        }

        public static void MOV_7a(CPU cpu, Memory memory)
        {
            int cycles = 5;
            SetTarget(cycles);
            int opcode = 0x7a;

            cpu.A = cpu.D;

            Debug.Print($"Processed Instruction MOV A,D ({opcode.ToString("X2")})");

            WaitForTarget();
            
        }

        public static void MOV_7b(CPU cpu, Memory memory)
        {
            int cycles = 5;
            SetTarget(cycles);
            int opcode = 0x7b;

            cpu.A = cpu.E;

            Debug.Print($"Processed Instruction MOV A,E ({opcode.ToString("X2")})");

            WaitForTarget();
            
        }

        public static void MOV_7c(CPU cpu, Memory memory)
        {
            int cycles = 5;
            SetTarget(cycles);
            int opcode = 0x7c;

            cpu.A = cpu.H;

            Debug.Print($"Processed Instruction MOV A,H ({opcode.ToString("X2")})");

            WaitForTarget();
            
        }

        public static void MOV_7d(CPU cpu, Memory memory)
        {
            int cycles = 5;
            SetTarget(cycles);
            int opcode = 0x7d;

            cpu.A = cpu.L;

            Debug.Print($"Processed Instruction MOV A,L ({opcode.ToString("X2")})");

            WaitForTarget();
            
        }

        public static void MOV_7e(CPU cpu, Memory memory)
        {
            int cycles = 7;
            SetTarget(cycles);
            int opcode = 0x7e;

            cpu.A = memory.ReadByte(cpu.HL);

            Debug.Print($"Processed Instruction MOV A,M ({opcode.ToString("X2")})");

            WaitForTarget();
            
        }

        public static void MOV_7f(CPU cpu, Memory memory)
        {
            int cycles = 5;
            SetTarget(cycles);
            int opcode = 0x7f;

            cpu.A = cpu.A;

            Debug.Print($"Processed Instruction MOV A,A ({opcode.ToString("X2")})");

            WaitForTarget();
            
        }
    }
}
