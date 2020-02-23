using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chapter_12_03_01
{
    public class FileOperations
    {
        public int ReadLength(string filename)
        {
            string content = File.ReadAllText(filename);
            return content.Length;
        }

        public Task<int> ReadLengthAsync2(string filename)
        {
            Task<int> length = File.ReadAllTextAsync(filename)
                .ContinueWith(t => t.Result.Length);
            return length;
        }

        public async Task<int> ReadLengthAsync3(string filename)
        {
            string content = await File.ReadAllTextAsync(filename);
            return content.Length;
        }
    }
}
