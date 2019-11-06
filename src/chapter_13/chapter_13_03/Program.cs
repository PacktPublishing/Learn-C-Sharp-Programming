using System;
using System.IO;
using System.Text;
using System.Xml;
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

      public static void Serialize(T value, XmlWriter stream, XmlSerializerNamespaces ns = null)
      {
         _serializer.Serialize(stream, value, ns);
      }

      public static T Deserialize(XmlReader stream)
      {
         return (T)_serializer.Deserialize(stream);
      }
   }

   class Program
   {
      static void Main(string[] args)
      {
         /*
         <?xml version="1.0" encoding="utf-8"?>
         <Employee xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema">
           <id>42</id>
           <firstName>John</firstName>
           <lastName>Doe</lastName>
         </Employee>
          */
         {
            var employee = new Employee
            {
               EmployeeId = 42,
               FirstName = "John",
               LastName = "Doe"
            };

            var path = Path.Combine(Path.GetTempPath(), "employee1.xml");
            Serializer<Employee>.Serialize(employee, path);
            var result = Serializer<Employee>.Deserialize(path);

            Console.WriteLine(employee);
            Console.WriteLine(File.ReadAllText(path));
            Console.WriteLine(result);

            File.Delete(path);
         }

         /*
         <?xml version="1.0" encoding="utf-8"?>
         <Employee xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema">
           <id>42</id>
           <firstName>John</firstName>
           <lastName>Doe</lastName>
         </Employee>
         <?xml version="1.0" encoding="utf-8"?>
         <Department xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" Id="102">
           <Name>IT</Name>
         </Department>
          */
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

            var path = Path.Combine(Path.GetTempPath(), "employee2.xml");
            using (var wr = File.CreateText(path))
            {
               Serializer<Employee>.Serialize(employee, wr);
               wr.WriteLine();
               Serializer<Department>.Serialize(department, wr);
            }

            Console.WriteLine(File.ReadAllText(path));

            File.Delete(path);
         }

         /*
         <?xml version="1.0" encoding="utf-8"?>
         <Data>
           <Employee>
             <id>42</id>
             <firstName>John</firstName>
             <lastName>Doe</lastName>
           </Employee>
           <Department Id="102">
             <Name>IT</Name>
           </Department>
         </Data>          
          */
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

            var path = Path.Combine(Path.GetTempPath(), "employee3.xml");

            var settings = new XmlWriterSettings 
            { 
               Encoding = Encoding.UTF8, 
               Indent = true 
            };

            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            using (var wr = XmlWriter.Create(path, settings))
            {
               wr.WriteStartDocument();
               wr.WriteStartElement("Data");
               Serializer<Employee>.Serialize(employee, wr, namespaces);
               Serializer<Department>.Serialize(department, wr, namespaces);
               wr.WriteEndElement();
               wr.WriteEndDocument();
            }

            Console.WriteLine(File.ReadAllText(path));

            var rdsettings = new XmlReaderSettings()
            {
               IgnoreComments = true,
               IgnoreWhitespace = true
            };

            using (var rd = XmlReader.Create(path, rdsettings))
            {
               //rd.ReadStartElement("Data");
             
               while(rd.Read())
               {
                  switch(rd.NodeType)
                  {
                     case XmlNodeType.Element:
                        Console.WriteLine();
                        Console.Write($"<{rd.Name}");
                        for(int i = 0; i < rd.AttributeCount; ++i)
                        {
                           var attribute = rd.GetAttribute(i);
                        }
                        Console.Write(">");
                        break;
                     case XmlNodeType.Text:
                        Console.Write(rd.Value);
                        break;
                     case XmlNodeType.EndElement:
                        Console.Write($"</{rd.Name}>");
                        break;
                     default:
                        Console.WriteLine($"{rd.NodeType}: {rd.Value}");
                        break;
                  }
               }
            }

            File.Delete(path);
         }
      }
   }
}
