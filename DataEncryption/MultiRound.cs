using DataEncryption.Algorithms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEncryption
{
    internal static class MultiRound
    {
        public static async Task Start()
        {
            var data = await FileSys.ReadFile("receipt.html");
            var s = EncryptAlg(new Substitution(), data, await FileSys.ReadKey("Substitution"));
            s.Wait();
            data = await FileSys.ReadFile("receipt2.html");
            await FileSys.GenerateKey(5, "Transposition");
            var t = EncryptAlg(new Transposition(), data, await FileSys.ReadKey("Transposition"));
            t.Wait();
            data = await FileSys.ReadFile("receipt2.html");
            await FileSys.GenerateKey(5, "XOR");
            var x = EncryptAlg(new XOR(), data, await FileSys.ReadKey("XOR"));
            x.Wait();
            Console.WriteLine("Нажмите для расшифровки");
            Console.ReadKey();

            data = await FileSys.ReadFile("receipt2.html");
            var ds = DecryptAlg(new Substitution(), data, await FileSys.ReadKey("Substitution"));
            ds.Wait();
            data = await FileSys.ReadFile("receipt2.html");
            var dt = DecryptAlg(new Transposition(), data, await FileSys.ReadKey("Transposition"));
            dt.Wait();
            data = await FileSys.ReadFile("receipt2.html");
            var dx = DecryptAlg(new XOR(), data, await FileSys.ReadKey("XOR"));
            dx.Wait();
            FileSys.Sys();
        }

        public static async Task EncryptAlg(IAlgorithm algorithm, List<byte> text, List<int> key)
        {
            var eText = algorithm.Encrypt(text, key);

            await FileSys.WriteText(eText, "receipt2.html");
        }

        public static async Task DecryptAlg(IAlgorithm algorithm, List<byte> text, List<int> key)
        {
            var dText = algorithm.Decrypt(text, key);

            await FileSys.WriteText(dText, "receipt2.html");
        }
    }
}
