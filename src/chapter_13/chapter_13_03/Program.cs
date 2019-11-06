using System;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace chapter_13_03
{
   public class Employee
   {
      [XmlElement(ElementName = "id")]
      public int EmployeeId { get; set; }

      [XmlElement(ElementName = "firstName")]
      public string FirstName { get; set; }

      [XmlElement(ElementName = "lastName")]
      public string LastName { get; set; }

      public override string ToString() => $"[{EmployeeId}] {LastName}, {FirstName}";
   }

   public class Department
   {
      [XmlAttribute]
      public int Id { get; set; }
      
      public string Name { get; set; }
   }

   public static class Serializer<T>
   {
      static readonly XmlSerializer _serializer = new XmlSerializer(
         typeof(T));

      public static void Serialize(T value, string path)
      {
         using var ms = File.CreateText(path);
         _serializer.Serialize(ms, value);
      }

      public static T Deserialize(string path)
      {
         using var ms = File.OpenText(path);
         return (T)_serializer.Deserialize(ms);
      }

      public static void Serialize(T value, StreamWriter stream)
      {
         _serializer.Serialize(stream, value);
      }

      public static T Deserialize(StreamReader stream)
      {
         return (T)_serializer.Deserialize(stream);
      }
   }

   class Program
   {
      static void Main(string[] args)
      {
         {
            var employee = new Employee
            {
               EmployeeId = 42,
               FirstName = "John",
               LastName = "Doe"
            };

            var path = Path.Combine(Path.GetTempPath(), "employee.xml");
            Serializer<Employee>.Serialize(employee, path);
            var result = Serializer<Employee>.Deserialize(path);

            Console.WriteLine(employee);
            Console.WriteLine(File.ReadAllText(path));
            Console.WriteLine(result);

            File.Delete(path);
         }

         {
            var employee = new Employee
            {
               EmployeeId = 42,
               FirstName = "John",
               LastName = "Doe"
            };

            var department = new Department
            {
               Id = 102,
               Name = "IT"
            };

            var path = Path.Combine(Path.GetTempPath(), "employee.xml");
            using (var wr = File.CreateText(path))
            {
               Serializer<Employee>.Serialize(employee, wr);
               Serializer<Department>.Serialize(department, wr);
            }

            Console.WriteLine(File.ReadAllText(path));

            File.Delete(path);
         }
      }
   }
}
