using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace chapter_13_05
{
   public enum EmployeeStatus
   {
      Active,
      Inactive
   }

   public class Employee
   {
      public int EmployeeId { get; set; }

      public string FirstName { get; set; }

      public string LastName { get; set; }

      public DateTime? HireDate { get; set; }

      public List<string> Telephones { get; set; }

      public bool IsOnLeave { get; set; }

      [JsonConverter(typeof(JsonStringEnumConverter))]
      public EmployeeStatus Status { get; set; }

      [JsonIgnore]
      public DateTime LastModified { get; set; }

      public override string ToString() => $"[{EmployeeId}] {LastName}, {FirstName}";
   }

   class Program
   {
      static void Main(string[] args)
      {
         var employee = new Employee
         {
            EmployeeId = 42,
            FirstName = "John",
            LastName = "Doe"
         };

         {
            var text = JsonSerializer.Serialize(employee);
            Console.WriteLine(text);
         }

         {
            var text = JsonSerializer.Serialize(
               employee,
               new JsonSerializerOptions()
               {
                  WriteIndented = true,
               });
            Console.WriteLine(text);
         }

         {
            var text = JsonSerializer.Serialize(
               employee,
               new JsonSerializerOptions()
               {
                  WriteIndented = true,
                  IgnoreNullValues = true                  
               });
            Console.WriteLine(text);
         }

         {
            var path = Path.Combine(Path.GetTempPath() + "employee.json");
            var options = new JsonWriterOptions()
            {
               Indented = true
            };

            using (var sw = File.CreateText(path))
            using (var jw = new Utf8JsonWriter(sw.BaseStream, options))
            {
               jw.WriteStartObject();
               jw.WriteNumber("EmployeeId", 42);
               jw.WriteString("FirstName", "John");
               jw.WriteString("LastName", "Doe");
               jw.WriteBoolean("IsOnLeave", false);
               jw.WriteString("Status", EmployeeStatus.Active.ToString());
               jw.WriteEndObject();
            }

            var text = File.ReadAllText(path);
            Console.WriteLine(text);

            byte[] data = Encoding.UTF8.GetBytes(text);
            Utf8JsonReader reader = new Utf8JsonReader(data, true, default);

            while (reader.Read())
            {
               switch (reader.TokenType)
               {
                  case JsonTokenType.PropertyName:
                     Console.Write($@"""{reader.GetString()}"" : ");
                     break;
                  case JsonTokenType.String:
                     {
                        Console.WriteLine($"{reader.GetString()},");
                        break;
                     }

                  case JsonTokenType.Number:
                     {
                        Console.WriteLine($"{reader.GetInt32()},");
                        break;
                     }
                  case JsonTokenType.False:
                  case JsonTokenType.True:
                     {
                        Console.WriteLine($"{reader.GetBoolean()},");
                        break;
                     }
               }
            }

            File.Delete(path);
         }
      }
   }
}
