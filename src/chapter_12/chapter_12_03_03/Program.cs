using System;
using System.Threading.Tasks;

namespace chapter_12_03_03
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var p = new Program();
            var s2 = await p.AddAsync2(1, 2);
        }

        public ValueTask<int> AddAsync2(int a, int b)
        {
            return new ValueTask<int>(a + b);
        }

    }
}
