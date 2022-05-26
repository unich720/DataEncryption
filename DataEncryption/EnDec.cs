using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEncryption
{
    public class EnDec
    {
        public static List<byte> Encrypt(List<byte> text, List<byte> key)
        {
            var tx = new List<byte>(text);
            for (int i = 0; i < tx.Count; i++)
            {
                var asd = i % key.Count;
                tx[i] = text[key[asd]];
            }
            return tx;
        }

        //public static List<byte> EncryptSubstitution(List<byte> text, List<byte> key)
        //{
        //    var tx = new List<byte>(text);
        //    for (int i = 0; i < tx.Count; i++)
        //    {
        //        tx[i] = key[tx[i]];
        //    }
        //    return tx;
        //}

        //public static List<byte> DecryptSubstitution(List<byte> text, List<byte> key)
        //{
        //    var tx = new List<byte>(text);
        //    for (int i = 0; i < tx.Count; i++)
        //    {
        //        tx[i] = (byte)key.IndexOf(tx[i]);
        //    }
        //    return tx;
        //}

        public static List<byte> Decrypt(List<byte> text, List<byte> key)
        {
            var tx = new List<byte>(text);
            for (int i = 0; i < tx.Count; i++)
            {
                var asd = i % key.Count;
                tx[i] = text[key[asd]];
            }
            return tx;
        }
    }
}
