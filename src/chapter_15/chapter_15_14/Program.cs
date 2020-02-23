using System;

namespace chapter_15_14
{
    /// <summary>
    /// Unmanaged constructed types
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Span<Header<int>> records1 = stackalloc Header<int>[10];
            Span<Header<long>> records2 = stackalloc Header<long>[10];
        }

        struct Header<T>
        {
            T Word1;
            T Word2;
            T Word3;
        }
    }
}
