using System;
using System.Threading.Tasks;

namespace chapter_12_03_01
{
    class Program
    {
        static string filename = "DeBelloGallico_LiberI.txt";

        static async Task Main(string[] args)
        {
            var f = new FileOperations();
            var len1 = f.ReadLength(filename);
            var len2 = await f.ReadLengthAsync2(filename);
            var len3 = await f.ReadLengthAsync3(filename);
        }
    }
}
