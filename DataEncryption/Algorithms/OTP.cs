using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEncryption.Algorithms
{
    internal class OTP: IAlgorithm
    {
        public List<byte> Encrypt(List<byte> text, List<int> key)
        {
            var tx = new List<byte>(text);
            int keyIndex = 0;
            for (int i = 0; i < tx.Count; i++)
            {
                tx[i] = (byte)(text[i] ^ key[keyIndex]);

                keyIndex++;
                if (keyIndex + 1 == key.Count)
                    keyIndex = 0;
            }
            return tx;
        }

        public List<byte> Decrypt(List<byte> text, List<int> key)
        {
            var tx = new List<byte>(text);
            int keyIndex = 0;
            for (int i = 0; i < tx.Count; i++)
            {
                tx[i] = (byte)(text[i] ^ key[keyIndex]);

                keyIndex++;
                if (keyIndex + 1 == key.Count)
                    keyIndex = 0;
            }
            return tx;
        }
    }
}
