using System;
using System.IO;

namespace chapter_13_01
{
   class Program
   {
      static void Main(string[] args)
      {
         {
            var path = @"c:\Windows\System32\mmc.exe";

            Console.WriteLine(Path.HasExtension(path));
            Console.WriteLine(Path.IsPathFullyQualified(path));
            Console.WriteLine(Path.IsPathRooted(path));

            Console.WriteLine(Path.GetPathRoot(path));
            Console.WriteLine(Path.GetDirectoryName(path));
            Console.WriteLine(Path.GetFileName(path));
            Console.WriteLine(Path.GetFileNameWithoutExtension(path));
            Console.WriteLine(Path.GetExtension(path));

            Console.WriteLine(Path.ChangeExtension(path, ".dll"));
         }

         {
            var path1 = Path.Combine(@"c:\temp", @"sub\data.txt");
            Console.WriteLine(path1); // c:\temp\sub\data.txt         

            var path2 = Path.Combine(@"c:\temp\sub", @"..\", "log.txt");
            Console.WriteLine(path2); // c:\temp\sub\..\log.txt
         }

         {
            var temp = Path.GetTempPath();
            var name = Path.GetRandomFileName();
            var path1 = Path.Combine(temp, name);
            Console.WriteLine(path1);

            var path2 = Path.GetTempFileName();
            Console.WriteLine(path2);
            File.Delete(path2);
         }

         {
            var dir = new DirectoryInfo(@"c:\Program Files (x86)\Microsoft SDKs\Windows\");

            Console.WriteLine($"Full name : {dir.FullName}");
            Console.WriteLine($"Name      : {dir.Name}");
            Console.WriteLine($"Parent    : {dir.Parent}");
            Console.WriteLine($"Root      : {dir.Root}");
            Console.WriteLine($"Created   : {dir.CreationTime}");
            Console.WriteLine($"Attributes: {dir.Attributes}");

            foreach(var subdir in dir.EnumerateDirectories())
            {
               Console.WriteLine(subdir.Name);
            }
         }

         {
            var dir = new DirectoryInfo(@"C:\Temp\Dir\Sub");
            Console.WriteLine($"Exists: {dir.Exists}");
            dir.Create();

            var sub = dir.CreateSubdirectory(@"sub1\sub2\sub3");
            Console.WriteLine(sub.FullName);

            sub.Delete();
            Console.WriteLine($"Exists: {dir.Exists}");
         }

         {
            var dir = new DirectoryInfo(@"c:\Program Files (x86)\Microsoft SDKs\Windows\v10.0A\bin\NETFX 4.8 Tools\");
            foreach(var file in dir.GetFiles("t*.exe"))
            {
               Console.WriteLine($"{file.Name} [{file.Length}] [{file.Attributes}]");
            }
         }
      }
   }
}
