using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VM8080
{
    public class Memory
    {
        private const int _SIZE = 65536;
        private byte[] _memory = new byte[_SIZE];

        public Memory()
        {

        }

        public int Size { get { return _SIZE; } }

        public byte ReadByte(ushort position)
        {
            return _memory[position];
        }

        public void WriteByte(ushort position, byte b)
        {
            _memory[position] = b;
        }

        internal ushort ReadWord(ushort position)
        {
            return BitConverter.ToUInt16(new byte[2] { _memory[position], _memory[position + 1] }, 0);
        }

        public void WriteWord(ushort position, int w)
        {
            byte[] bytes = BitConverter.GetBytes(w);
            _memory[position] = bytes[0];
            _memory[position + 1] = bytes[1];
        }
    }
}
