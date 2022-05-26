using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEncryption.Algorithms
{
    internal class CircularShift
    {
        public List<byte> Encrypt(List<byte> text, List<int> key)
        {
            var tx = new List<byte>();
            for (int i = 0; i < text.Count; i++)
            {
                tx.Add((byte)(text[i]<<1));
            }
            return tx;
        }

        public List<byte> Decrypt(List<byte> text, List<int> key)
        {
            var tx = new List<byte>();
            for (int i = 0; i < text.Count; i++)
            {
                tx.Add((byte)(text[i] >> 1));
            }
            return tx;
        }
    }
}
