using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace chapter_12_03_10
{
    public class MonitorProgress
    {
        public async Task Load(IProgress<int> progress = null)
        {
            var steps = 30;
            for (int i = 0; i < steps; i++)
            {
                await Task.Delay(300);
                progress?.Report((i + 1) * 100 / steps);
            }
        }

    }

    public class ConsoleProgress : IProgress<int>
    {
        void IProgress<int>.Report(int value) =>
            Console.Write($"{value}%  ");
    }

}
