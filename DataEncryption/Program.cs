using DataEncryption.Algorithms;
using System;
using System.Text;
using System.Threading.Tasks;

namespace DataEncryption
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            //Console.WriteLine("Hello World!");

            //var text = await FileSys.ReadFile("receipt.html");

            //var algorithm = new CircularShift();

            ////await FileSys.GenerateKey(5);

            //var key = await FileSys.ReadKey();

            //var eText = algorithm.Encrypt(text, key);

            //await FileSys.WriteText(eText, "receipt2.html");

            //Console.WriteLine("Нажмите для расшифровки");
            //Console.ReadKey();

            //var text2 = await FileSys.ReadFile("receipt2.html");

            ////key = await FileSys.ReadKey();

            //var dText = algorithm.Decrypt(text2, key);

            //await FileSys.WriteText(text, "receipt2.html");

            await MultiRound.Start();

            //Console.ReadKey();
        }
    }
}
