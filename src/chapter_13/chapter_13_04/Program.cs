using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.IO;

namespace chapter_13_04
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
      
      [JsonConverter(typeof(StringEnumConverter))]
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
            var text = JsonConvert.SerializeObject(employee);
            Console.WriteLine(text);
         }

         {
            var text = JsonConvert.SerializeObject(employee, Formatting.Indented);
            Console.WriteLine(text);
         }

         {
            var text = JsonConvert.SerializeObject(
               employee,
               Formatting.Indented,
               new JsonSerializerSettings()
               {
                  NullValueHandling = NullValueHandling.Ignore,
               });
            Console.WriteLine(text);
         }

         {
            var text = JsonConvert.SerializeObject(
               employee,
               Formatting.Indented,
               new JsonSerializerSettings()
               {
                  NullValueHandling = NullValueHandling.Ignore,
                  DefaultValueHandling = DefaultValueHandling.Ignore
               });
            Console.WriteLine(text);
         }

         {
            var path = Path.Combine(Path.GetTempPath() + "employee.json");
            var serializer = new JsonSerializer()
            {
               Formatting = Formatting.Indented,
               NullValueHandling = NullValueHandling.Ignore,
               DefaultValueHandling = DefaultValueHandling.Ignore
            };

            using (var sw = File.CreateText(path))
            using (var jw = new JsonTextWriter(sw))
            {
               serializer.Serialize(jw, employee);
            }

            Console.WriteLine(File.ReadAllText(path));

            using (var sr = File.OpenText(path))
            using (var jr = new JsonTextReader(sr))
            {
               var result = serializer.Deserialize<Employee>(jr);

               Console.WriteLine(result);
            }

            File.Delete(path);
         }

         var json =
@"{
  ""EmployeeId"": 42,
  ""FirstName"": ""John"",
  ""LastName"": ""Doe""
}";
         Console.WriteLine(json);

         {
            var result = JsonConvert.DeserializeObject<Employee>(json);

            Console.WriteLine(result);
         }
      }
   }
}
