using System;
using System.IO;

namespace chapter_13_02
{
   class Program
   {
      static void Main(string[] args)
      {
         // binary data
         {
            var path = @"C:\Temp\data.bin";
            using (var wr = new BinaryWriter(File.Create(path)))
            {
               wr.Write(true);
               wr.Write('x');
               wr.Write(42);
               wr.Write(19.99);
               wr.Write(49.99M);
               wr.Write("text");
            }

            using(var rd = new BinaryReader(File.OpenRead(path)))
            {
               Console.WriteLine(rd.ReadBoolean());  // True
               Console.WriteLine(rd.ReadChar());     // x
               Console.WriteLine(rd.ReadInt32());    // 42
               Console.WriteLine(rd.ReadDouble());   // 19.99
               Console.WriteLine(rd.ReadDecimal());  // 49.99
               Console.WriteLine(rd.ReadString());   // text
            }
         }

         // text data
         {
            var path = @"C:\Temp\data.txt";
            using(var wr = File.CreateText(path))
            {
               wr.WriteLine("1st line");
               wr.WriteLine("2nd line");
            }

            using(var rd = File.OpenText(path))
            {
               while(!rd.EndOfStream)
                  Console.WriteLine(rd.ReadLine());
            }

            using(var rd = new StreamReader(File.Open(path, FileMode.Open, FileAccess.Read, FileShare.Read)))
            {
               while (!rd.EndOfStream)
                  Console.WriteLine(rd.ReadLine());
            }
         }
      }
   }
}
