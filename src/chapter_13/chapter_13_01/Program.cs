using System;
using System.IO;

namespace chapter_13_01
{
   class Program
   {
      static void PrintContent(string path, string indent = null)
      {
         try
         {
            foreach(var file in Directory.EnumerateFiles(path))
            {
               var fi = new FileInfo(file);
               Console.WriteLine($"{indent}{fi.Name}");
            }

            foreach(var dir in Directory.EnumerateDirectories(path))
            {
               var di = new DirectoryInfo(dir);
               Console.WriteLine($"{indent}[{di.Name}]");
               PrintContent(dir, indent + "  ");
            }
         }
         catch(Exception ex)
         {
            Console.Error.WriteLine(ex.Message);
         }
      }

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
            var dir = new DirectoryInfo(@"C:\Program Files (x86)\Microsoft SDKs\Windows\");

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
         }

         {
            var dir = new DirectoryInfo(@"C:\Program Files (x86)\Microsoft SDKs\Windows\v10.0A\bin\NETFX 4.8 Tools\");
            foreach(var file in dir.GetFiles("t*.exe"))
            {
               Console.WriteLine($"{file.Name} [{file.Length}] [{file.Attributes}]");
            }
         }

         {
            var path = @"C:\Temp\Dir\Sub";
            Console.WriteLine($"Exists: {Directory.Exists(path)}");
            Directory.CreateDirectory(path);

            var sub = Path.Combine(path, @"sub1\sub2\sub3");
            Directory.CreateDirectory(sub);

            Directory.Delete(sub);
            Directory.Delete(path, true);
         }

         {
            var file = new FileInfo(@"C:\Windows\explorer.exe");

            Console.WriteLine($"Name:       {file.Name}");
            Console.WriteLine($"Extension:  {file.Extension}");
            Console.WriteLine($"Full name:  {file.FullName}");
            Console.WriteLine($"Length:     {file.Length}");
            Console.WriteLine($"Attributes: {file.Attributes}");
            Console.WriteLine($"Creation:   {file.CreationTime}");
            Console.WriteLine($"Last access:{file.LastAccessTime}");
            Console.WriteLine($"Last write: {file.LastWriteTime}");
         }

         {
            PrintContent(@".\..\..\..\");
         }

         {
            var path = @"C:\Temp\Dir\demo.txt";
            using (var file = new StreamWriter(File.Create(path)))
            {
               file.Write("This is a demo");
            }

            File.WriteAllText(path, "This is a demo");
            File.AppendAllText(path, "1st line");
            File.AppendAllLines(path, new string[]{ "2nd line", "3rd line"});

            string text = File.ReadAllText(path);
            string[] lines = File.ReadAllLines(path);

            File.Delete(path);
         }
      }
   }
}
