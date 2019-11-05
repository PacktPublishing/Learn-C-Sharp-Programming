using System;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace chapter_13_02
{
   public class Employee
   {
      public int EmployeeId { get; set; }
      public string FirstName { get; set; }
      public string LastName { get; set; }

      public override string ToString() => $"[{EmployeeId}] {LastName}, {FirstName}";
   }

   public static class Serializer<T>
   {
      static readonly XmlSerializer _serializer = new XmlSerializer(
         typeof(T));

      static readonly Encoding _encoding = Encoding.UTF8;

      public static string Serialize(T value)
      {
         using (var ms = new MemoryStream())
         {
            _serializer.Serialize(ms, value);
            return _encoding.GetString(ms.ToArray());
         }
      }

      public static T Deserialize(string value)
      {
         using (var ms = new MemoryStream(_encoding.GetBytes(value)))
         {
            return (T)_serializer.Deserialize(ms);
         }
      }
   }

   public static class Compression
   {
      public static byte[] Compress(byte[] data)
      {
         if (data == null) return null;
         if (data.Length == 0) return new byte[] { };

         using var ms = new MemoryStream();
         using var gzips = new GZipStream(ms, CompressionMode.Compress);
         gzips.Write(data, 0, data.Length);
         gzips.Close();
         return ms.ToArray();
      }

      public static byte[] Decompress(byte[] data)
      {
         if (data == null) return null;
         if (data.Length == 0) return new byte[] { };
         
         using var source = new MemoryStream(data);
         using var gzips = new GZipStream(source, CompressionMode.Decompress);
         using var target = new MemoryStream(data.Length * 2);
         gzips.CopyTo(target);
         return target.ToArray();
      }
   }

   class Program
   {
      static void Main(string[] args)
      {
         // raw data
         {
            var path = @"C:\Temp\data.raw";
            var data = new byte[] { 0xBA, 0xAD, 0xF0, 0x0D};
            using(FileStream wr = File.Create(path))
            {
               wr.Write(data, 0, data.Length);
            }
            
            using(FileStream rd = File.OpenRead(path))
            {
               var buffer = new byte[rd.Length];
               rd.Read(buffer, 0, buffer.Length);

               Console.WriteLine(string.Join(" ", buffer.Select(e => $"{e:X02}")));
            }
         }

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
            using(StreamWriter wr = File.CreateText(path))
            {
               wr.WriteLine("1st line");
               wr.WriteLine("2nd line");
            }

            using(StreamReader rd = File.OpenText(path))
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

         // XML serialization
         {
            var employee = new Employee
            {
               EmployeeId = 42,
               FirstName = "John",
               LastName = "Doe"
            };
            
            var text = Serializer<Employee>.Serialize(employee);
            var result = Serializer<Employee>.Deserialize(text);

            Console.WriteLine(employee);
            Console.WriteLine(text);
            Console.WriteLine(result);
         }

         // data compression
         {
            var text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.";
            var data = Encoding.UTF8.GetBytes(text);
            var compressed = Compression.Compress(data);
            var decompressed = Compression.Decompress(compressed);
            var result = Encoding.UTF8.GetString(decompressed);

            Console.WriteLine($"Text size:    {text.Length}");
            Console.WriteLine($"Compressed:   {compressed.Length}");
            Console.WriteLine($"Decompressed: {decompressed.Length}");
            Console.WriteLine(result);
            if (text == result)
               Console.WriteLine("Decompression successful!");
         }
      }
   }
}
