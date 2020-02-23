using System;
using System.IO;
using System.Threading.Tasks;

namespace chapter_12_03_05
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var filename = "DeBelloGallico_LiberI.txt";
            var p = new Program();
            var len = await p.ReadLengthAsync(filename);
            Console.WriteLine(len);
        }

        public Task<int> ReadLengthAsync(string filename)
        {
            return Task.Run<int>(() =>
            {
                var content = File.ReadAllText(filename);
                return content.Length;
            });
        }


    }
}
