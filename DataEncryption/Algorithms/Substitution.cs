using DataEncryption.Algorithms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEncryption
{
    internal class Substitution : IAlgorithm
    {
        public List<byte> Encrypt(List<byte> text, List<int> key)
        {
            var tx = new List<byte>(text);
            for (int i = 0; i < tx.Count; i++)
            {
                tx[i] = (byte)key[tx[i]];
            }
            return tx;
        }

        public List<byte> Decrypt(List<byte> text, List<int> key)
        {
            var tx = new List<byte>(text);
            for (int i = 0; i < tx.Count; i++)
            {
                tx[i] = (byte)key.IndexOf(tx[i]);
            }
            return tx;
        }

    }
}
