using System;
using System.IO;
using System.Threading.Tasks;

namespace chapter_12_03_02
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var p = new Program();

            await p.WriteEmptyJsonObjectAsync("foo.json");
            var s1 = await p.AddAsync1(1, 2);
        }

        public Task WriteEmptyJsonObjectAsync(string filename)
        {
            File.WriteAllText(filename, "{}");
            return Task.CompletedTask;
        }

        public Task<int> AddAsync1(int a, int b)
        {
            return Task.FromResult(a + b);
        }

    }
}
