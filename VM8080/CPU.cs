using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VM8080
{
    public class CPU
    {
        private byte[] _buffer = new byte[10];
        private int _bufferSize = 0;
        private string _instructionString = String.Empty;

        private byte _A = 0;
        private byte _B = 0;
        private byte _C = 0;
        private byte _D = 0;
        private byte _E = 0;
        private byte _H = 0;
        private byte _L = 0;
        private byte _Flags = 0x02;
        private ushort _SP = 0;
        private ushort _PC = 0;

        private bool _halted = false;

        private const byte _CARRY_MASK = 0x01;
        private const byte _PARITY_MASK = 0x04;
        private const byte _AUXCARRY_MASK = 0x10;
        private const byte _ZERO_MASK = 0x40;
        private const byte _SIGN_MASK = 0x80;

        public byte A { get { return _A; } set { _A = value; } }
        public byte B { get { return _B; } set { _B = value; } }
        public byte C { get { return _C; } set { _C = value; } }
        public byte D { get { return _D; } set { _D = value; } }
        public byte E { get { return _E; } set { _E = value; } }
        public byte H { get { return _H; } set { _H = value; } }
        public byte L { get { return _L; } set { _L = value; } }
        public byte Flags { get { return _Flags; } set { _Flags = (byte)(value | 0x02); } }
        public ushort SP { get { return _SP; } set { _SP = value; } }
        public ushort PC { get { return _PC; } set { _PC = value; } }
        public ushort PSW
        {
            get
            {
                return BitConverter.ToUInt16(new byte[2] { _Flags, _A }, 0);
            }
            set
            {
                byte[] bs = BitConverter.GetBytes(value);
                _Flags = (byte)(bs[0] | 0x02);
                _A = bs[1];
            }
        }
        public ushort BC
        {
            get
            {
                return BitConverter.ToUInt16(new byte[2] { _C, _B }, 0);
            }
            set
            {
                byte[] bs = BitConverter.GetBytes(value);
                _C = bs[0];
                _B = bs[1];
            }
        }
        public ushort DE
        {
            get
            {
                return BitConverter.ToUInt16(new byte[2] { _E, _D }, 0);
            }
            set
            {
                byte[] bs = BitConverter.GetBytes(value);
                _E = bs[0];
                _D = bs[1];
            }
        }
        public ushort HL
        {
            get
            {
                return BitConverter.ToUInt16(new byte[2] { _L, _H }, 0);
            }
            set
            {
                byte[] bs = BitConverter.GetBytes(value);
                _L = bs[0];
                _H = bs[1];
            }
        }

        public bool Halted { get { return _halted; } set { _halted = value; } }

        public bool FlagCarry
        {
            get
            {
                return ((Flags & _CARRY_MASK) == _CARRY_MASK);
            }
            set
            {
                if (value)
                {
                    Flags |= _CARRY_MASK;
                }
                else
                {
                    Flags &= (0xff - _CARRY_MASK);
                }
            }
        }

        public bool FlagParity
        {
            get
            {
                return ((Flags & _PARITY_MASK) == _PARITY_MASK);
            }
            set
            {
                if (value)
                {
                    Flags |= _PARITY_MASK;
                }
                else
                {
                    Flags &= (0xff - _PARITY_MASK);
                }
            }
        }

        public bool FlagAuxCarry
        {
            get
            {
                return ((Flags & _AUXCARRY_MASK) == _AUXCARRY_MASK);
            }
            set
            {
                if (value)
                {
                    Flags |= _AUXCARRY_MASK;
                }
                else
                {
                    Flags &= (0xff - _AUXCARRY_MASK);
                }
            }
        }

        public bool FlagZero
        {
            get
            {
                return ((Flags & _ZERO_MASK) == _ZERO_MASK);
            }
            set
            {
                if (value)
                {
                    Flags |= _ZERO_MASK;
                }
                else
                {
                    Flags &= (0xff - _ZERO_MASK);
                }
            }
        }

        public bool FlagSign
        {
            get
            {
                return ((Flags & _SIGN_MASK) == _SIGN_MASK);
            }
            set
            {
                if (value)
                {
                    Flags |= _SIGN_MASK;
                }
                else
                {
                    Flags &= (0xff - _SIGN_MASK);
                }
            }
        }

        public void AddOpcode(byte opCode)
        {
            _bufferSize = 0;
            AddBufferData(opCode);
        }

        public void AddBufferData(byte data)
        {
            _buffer[_bufferSize] = data;
            _bufferSize++;
        }

        public void AddInstructionString(string instructionString)
        {
            _instructionString = instructionString;
        }

        public void PrintDebug()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Processed Instruction {_instructionString} [ ");
            for(int i = 0; i < _bufferSize; i++)
            {
                sb.Append($"{_buffer[i].ToString("X2")} ");
            }
            sb.Append("]");
            Debug.Print(sb.ToString());
        }
    }
}
