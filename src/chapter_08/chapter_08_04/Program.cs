using System;

namespace chapter_08_04
{
   class Airplane
   {
      public void Fly() { }
   }

   class Bike
   {
      public void Ride() { }
   }

   class Car
   {
      public bool HasAutoDrive { get; }

      public void Drive() { }
      public void AutoDrive() { }
   }

   class Program
   {
      static void Main(string[] args)
      {
         bool IsTrue(object value)
         {
            if (value is null) return false;
            else if (value is 1) return true;
            else if (value is true) return true;
            else if (value is "true") return true;
            else if (value is "1") return true;
            return false;
         }

         void SetInMotion1(object vehicle)
         {
            if (vehicle is null)
               throw new ArgumentNullException(
                     message: "Vehicle must not be null",
                     paramName: nameof(vehicle));
            else if (vehicle is Airplane a)
               a.Fly();
            else if (vehicle is Bike b)
               b.Ride();
            else if (vehicle is Car c)
               if (c.HasAutoDrive) c.AutoDrive();
               else c.Drive();
            else
               throw new ArgumentException(
                  message: "Unexpected vehicle type",
                  paramName: nameof(vehicle));
         }

         void SetInMotion2(object vehicle)
         {
            switch (vehicle)
            {
               case Airplane a:
                  a.Fly();
                  break;
               case Bike b:
                  b.Ride();
                  break;
               case Car c:
                  if (c.HasAutoDrive) c.AutoDrive();
                  else c.Drive();
                  break;
               case null:
                  throw new ArgumentNullException(
                     message: "Vehicle must not be null",
                     paramName: nameof(vehicle));
               default:
                  throw new ArgumentException(
                     message: "Unexpected vehicle type",
                     paramName: nameof(vehicle));
            }
         }

         void SetInMotion3(object vehicle)
         {
            switch (vehicle)
            {
               case Airplane a:
                  a.Fly();
                  break;
               case Bike b:
                  b.Ride();
                  break;
               case Car c when c.HasAutoDrive:
                  c.AutoDrive();
                  break;
               case Car c:
                  c.Drive();
                  break;
               case null:
                  throw new ArgumentNullException(
                     message: "Vehicle must not be null",
                     paramName: nameof(vehicle));
               default:
                  throw new ArgumentException(
                     message: "Unexpected vehicle type",
                     paramName: nameof(vehicle));
            }
         }

         void ExecuteCommand(string command)
         {
            switch (command)
            {
               case "add":  /* add */ break;
               case "del":  /* delete */ break;
               case "exit": /* exit */ break;
               case var o when (o?.Trim().Length ?? 0) == 0:
                  /* do nothing */
                  break;
               default:
                  /* invalid command */
                  break;
            }
         }

         Console.WriteLine(IsTrue(null));    // False
         Console.WriteLine(IsTrue(0));       // False
         Console.WriteLine(IsTrue(1));       // True
         Console.WriteLine(IsTrue(true));    // True
         Console.WriteLine(IsTrue("true"));  // True
         Console.WriteLine(IsTrue("1"));     // True
         Console.WriteLine(IsTrue("demo"));  // False

         SetInMotion1(new Car());
         SetInMotion2(new Car());
         SetInMotion3(new Car());

         ExecuteCommand("add");
         ExecuteCommand("quit");
         ExecuteCommand(null);
      }
   }
}
