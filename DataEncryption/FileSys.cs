using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEncryption
{
    public static class FileSys
    {
        public async static Task<List<byte>> ReadFile(string file)
        {
            var text = await File.ReadAllBytesAsync(Directory.GetCurrentDirectory() + "//"+ file);
            return new List<byte>(text);
        }

        public async static Task GenerateKey(int count, string name)
        {
            //var text = await File.ReadAllBytesAsync(Directory.GetCurrentDirectory() + "//key.txt");
            var keySort  = Enumerable.Range(0, count).ToList();
            Random random = new Random();
            for (int i = keySort.Count - 1; i >= 1; i--)
            {
                int j = random.Next(i + 1);
                // обменять значения data[j] и data[i]
                var temp = keySort[j];
                keySort[j] = keySort[i];
                keySort[i] = temp;
            }

            var text = String.Join(",", keySort.ToArray());

            await File.WriteAllTextAsync(Directory.GetCurrentDirectory() + "//" + name+ ".txt", text);
        }

        public async static Task GenerateKeyASCII(int count)
        {
            //var text = await File.ReadAllBytesAsync(Directory.GetCurrentDirectory() + "//key.txt");
            var keySort = Enumerable.Range(0, count).ToList();
            Random random = new Random();
            for (int i = 0; i < count; i++)
            {
                keySort[i] = random.Next(256);
            }

            var text = String.Join(",", keySort.ToArray());

            await File.WriteAllTextAsync(Directory.GetCurrentDirectory() + "//key.txt", text);
        }

        public async static Task<List<int>> ReadKey(string name)
        {
            var text = await File.ReadAllTextAsync(Directory.GetCurrentDirectory() + $"//{name}.txt");
            var keys = text.Split(',');
            var list = new List<string>(keys).Select(x => Convert.ToInt32(x)).ToList();
            return list;
        }

        public static string GetASCII(List<byte> list)
        {
            //var sda = list.ToArray();
            var text = Encoding.ASCII.GetString(list.ToArray());
            return text;
        }

        public async static Task WriteText(List<byte> list, string file)
        {
            await File.WriteAllBytesAsync(Directory.GetCurrentDirectory() + "//"+ file, list.ToArray());
        }

        public static void Sys()
        {
            var data = Task.Run(async () => { var dText = await FileSys.ReadFile("receipt.html"); await FileSys.WriteText(dText, "receipt2.html"); });
            data.Wait();
        }
    }
}
