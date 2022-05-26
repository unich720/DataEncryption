using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEncryption.Algorithms
{
    public interface IAlgorithm
    {
        List<byte> Encrypt(List<byte> text, List<int> key);
        List<byte> Decrypt(List<byte> text, List<int> key);
    }
}
