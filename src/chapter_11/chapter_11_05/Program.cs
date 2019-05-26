using System;
using System.Runtime.InteropServices;

namespace chapter_11_05
{
   [Flags]
   enum Options
   {
      None,
      Read,
      Write,
      Delete
   }

   [Serializable]
   struct Point
   {
      int X;
      int Y;
      int Z;
   }

   [Obsolete]
   class Foo
   {
      public void DoStuff() { }
   }
   
   class DescriptionAttribute : Attribute
   {
      public string Text { get; private set; }
      public bool Required { get; set; }

      public DescriptionAttribute(string description)
      {
         Text = description;
      }
   }

   [AttributeUsage(AttributeTargets.Class|
                   AttributeTargets.Struct|
                   AttributeTargets.Method|
                   AttributeTargets.Property|
                   AttributeTargets.Field,
                   AllowMultiple = true,
                   Inherited = true)]
   class Description2Attribute : Attribute
   {
      public string Text { get; private set; }
      public bool Required { get; set; }

      public Description2Attribute(string description)
      {
         Text = description;
      }
   }

   [Description("Main component of the car", 
                Required = true)]
   class Engine
   {
      public string Name { get; }

      [Description("cm³")]
      public int Capacity { get; }

      [Description("kW")]
      public double Power { get; }

      public Engine([Description("The name")] string name, 
                    [Description("The capacity")] int capacity, 
                    [Description("The power")] double power)
      {
         Name = name;
         Capacity = capacity;
         Power = power;
      }
   }

   [Serializable]
   [Description("Main component of the car")]
   [ComVisible(false)]
   class Engine1
   {

   }

   [Serializable, 
    Description("Main component of the car"), 
    ComVisible(false)]
   class Engine2
   {

   }

   [Description2("Main component of the car")]
   class Engine3
   {
      public string Name { get; }

      [Description2("cm³")]
      public int Capacity { get; }

      [Description2("kW")]
      public double Power { get; }

      public Engine3(/*[Description2("The name")]*/ string name,
                     /*[Description2("The capacity")]*/ int capacity,
                     /*[Description2("The power")]*/ double power)
      {
         Name = name;
         Capacity = capacity;
         Power = power;
      }
   }

   class Program
   {
      static void Main(string[] args)
      {
         var f = new Foo();
         f.DoStuff();

         var e = new Engine("M270 Turbo", 1600, 75.0);

         var type = e.GetType();

         var attributes = type.GetCustomAttributes(typeof(DescriptionAttribute), true);
         if (attributes != null)
         {
            foreach (DescriptionAttribute attr in attributes)
            {
               Console.WriteLine(attr.Text);
            }
         }

         var properties = type.GetProperties();
         foreach (var property in properties)
         {
            var pattributes = property.GetCustomAttributes(typeof(DescriptionAttribute), false);
            if (attributes != null)
            {
               foreach (DescriptionAttribute attr in pattributes)
               {
                  Console.WriteLine($"{property.Name} [{attr.Text}]");
               }
            }
         }
      }
   }
}
