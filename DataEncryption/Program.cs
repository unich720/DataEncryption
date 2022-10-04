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
            Console.WriteLine("1 Выбор алгоритма шифрования");
            Console.WriteLine("2 Зашифровать");
            Console.WriteLine("3 Расшифровать");

            IAlgorithm algorithm = new Transposition();


            while (true)
            {
                Console.WriteLine("Алгоритм: "+ algorithm.GetType().Name);
                var sign = Convert.ToInt32(Console.ReadLine());
                switch (sign)
                {
                    case 1:
                        {
                            Console.WriteLine("1 XOR");
                            Console.WriteLine("2 Transposition");
                            Console.WriteLine("3 Substitution");
                            Console.WriteLine("4 OTP");
                            var sign2 = Convert.ToInt32(Console.ReadLine());
                            switch (sign2)
                            {
                                case 1:
                                    {
                                        algorithm = new XOR();
                                        break;
                                    }
                                case 2:
                                    {
                                        algorithm = new Transposition();
                                        break;
                                    }
                                case 3:
                                    {
                                        algorithm = new Substitution();
                                        break;
                                    }
                                case 4:
                                    {
                                        algorithm = new OTP();
                                        break;
                                    }
                                default:
                                    break;
                            }
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("Зашивровал");
                            var data = await FileSys.ReadFile("receipt.html");
                            var keyLenght = 5;
                            if (algorithm.GetType().Name == "Substitution")
                            {
                                keyLenght = 255;
                            }
                            await FileSys.GenerateKey(keyLenght, algorithm.GetType().Name);
                            var t = MultiRound.EncryptAlg(algorithm, data, await FileSys.ReadKey(algorithm.GetType().Name));
                            t.Wait();
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("Расшифровал");
                            var data = await FileSys.ReadFile("receipt2.html");
                            var ds = MultiRound.DecryptAlg(algorithm, data, await FileSys.ReadKey(algorithm.GetType().Name));
                            ds.Wait();
                            break;
                        }
                    default:
                        break;
                }
            }
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
