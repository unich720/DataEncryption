using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEncryption.Algorithms
{
    internal class Transposition : IAlgorithm
    {
        public List<byte> Encrypt(List<byte> text, List<int> key)
        {
            var tx = new List<byte>(text);
            for (int i = 0; i < tx.Count; i++)
            {
                var asd = i % key.Count;
                if (i - asd + key[asd] >= text.Count)
                    continue;
                tx[i] = text[i-asd+key[asd]];
            }
            return tx;
        }

        public List<byte> Decrypt(List<byte> text, List<int> key)
        {
            var tx = new List<byte>(text);
            for (int i = 0; i < tx.Count; i++)
            {
                var asd = i % key.Count;
                if (i - asd + key.IndexOf(asd) >= text.Count)
                    continue;
                tx[i] = text[i - asd + key.IndexOf(asd)];
            }
            return tx;
        }
    }
}
