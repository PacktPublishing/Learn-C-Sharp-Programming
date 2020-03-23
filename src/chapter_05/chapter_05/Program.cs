using System;
using System.Collections.Generic;

namespace chapter_05
{
   class Base
   {
      public int Get() { return 42; }
   }

   class Derived : Base
   {
      public new int Get() { return 10; }
   }

   class Pet
   {
      public string Name { get; private set; }

      public Pet(string name)
      { Name = name; }

      public Pet Clone() { return new Pet(Name); }
   }

   class Dog : Pet
   {
      public string Color { get; private set; }

      public Dog(string name, string color):base(name)
      { Color = color; }

      public new Dog Clone() { return new Dog(Name, Color); }
   }

   class Riddle<T>
   {
      public void Apply(T value) 
      { 
         Console.WriteLine($"T is {value}"); 
      }

      public void Apply(int value) 
      { 
         Console.WriteLine($"int is {value}"); 
      }
   }

   class Program
   {
      static void Main(string[] args)
      {
         Employee employee = new Employee("John Doe", 2500);
         Console.WriteLine($"{employee.Name} earns {employee.Salary}");
         employee.GiveRaise(5.5);
         Console.WriteLine($"{employee.Name} earns {employee.Salary}");

         {
            var objects = new List<v1.GameUnit>()
            {
               new v1.Water(new Position(3, 2)),
               new v1.Water(new Position(4, 2)),
               new v1.Water(new Position(5, 2)),
               new v1.Hill(new Position(3, 1)),
               new v1.Hill(new Position(5, 3)),
            };

            var surface = new v1.Surface();
            surface.BeginDraw();

            foreach (var unit in objects)
               unit.Draw(surface);

            Console.ReadLine();
         }

         {
            var objects = new List<v2.GameUnit>()
            {
               new v2.Water(new Position(3, 2)),
               new v2.Water(new Position(4, 2)),
               new v2.Water(new Position(5, 2)),
               new v2.Hill(new Position(3, 1)),
               new v2.Hill(new Position(5, 3)),
            };

            var surface = new v1.Surface();
            surface.BeginDraw();

            foreach (var unit in objects)
               unit.Draw(surface);

            Console.ReadLine();
         }

         {
            var objects = new List<v3.GameUnit>()
            {
               new v3.Water(new Position(3, 2)),
               new v3.Water(new Position(4, 2)),
               new v3.Water(new Position(5, 2)),
               new v3.Hill(new Position(3, 1)),
               new v3.Hill(new Position(5, 3)),
            };

            var surface = new v1.Surface();
            surface.BeginDraw();

            foreach (var unit in objects)
               unit.Draw(surface);

            Console.ReadLine();
         }

         {
            var objects = new List<v6.GameUnit>()
            {
               new v6.Water(new Position(3, 2)),
               new v6.Water(new Position(4, 2)),
               new v6.Water(new Position(5, 2)),
               new v6.Hill(new Position(3, 1)),
               new v6.Hill(new Position(5, 3)),
            };

            var surface = new v6.Surface();
            surface.BeginDraw();

            foreach (var unit in objects)
               unit.Draw(surface);

            Console.ReadLine();
         }

         {
            var objects = new List<v6.GameUnit>()
            {
               new v6.Water(new Position(3, 2)),
               new v6.Water(new Position(4, 2)),
               new v6.Water(new Position(5, 2)),
               new v6.Hill(new Position(3, 1)),
               new v6.Hill(new Position(5, 3)),
               new v6.Meeple(new Position(0, 0)),
               new v6.Meeple(new Position(4, 3)),
            };

            var surface = new v6.Surface();
            surface.BeginDraw();

            foreach (var unit in objects)
               unit.Draw(surface);

            surface.EndDraw();
            Console.ReadLine();
         }

         {
            var objects = new v6.GameUnit[]
            {
                new v6.Water(new Position(3, 2)),
                new v6.Hill(new Position(3, 1)),
                new v6.Meeple(new Position(0, 0)),
            };
         }

         {
            Derived d = new Derived();
            Console.WriteLine(d.Get()); // prints 10

            Base b = d;
            Console.WriteLine(b.Get()); // prints 42
         }

         {
            v7.Meeple m = new v7.Meeple(new Position(3, 4));
            m.MoveTo(new Position(1, 1));
            m.MoveTo(2, 5);
         }

         {
            var r = new Riddle<int>();
            r.Apply(42);
         }

         {
            var c1 = new Complex(2, 3);
            var c2 = new Complex(4, 5);

            var c3 = c1 + c2;
            var c4 = c1 - c2;

            if (c3 == c2) { /* do something */}
            if (c1 != c4) { /* do something else */}

            var c5 = new Complex(5, 7);
            Console.WriteLine(c5);  // 5i + 7

            c5++;
            Console.WriteLine(c5);  // 6i + 7

            ++c5;
            Console.WriteLine(c5);  // 7i + 7
         }

         {
            var c1 = new v2.Complex(5, 7);
            var c2 = c1;
            Console.WriteLine(c1);  // 5i + 7
            Console.WriteLine(c2);  // 5i + 7

            c1++;
            Console.WriteLine(c1);  // 6i + 7
            Console.WriteLine(c2);  // 6i + 7
         }

         {
            var c1 = new v3.Complex(5, 7);
            var c2 = c1;
            Console.WriteLine(c1);  // 5i + 7
            Console.WriteLine(c2);  // 5i + 7

            c1++;
            Console.WriteLine(c1);  // 6i + 7
            Console.WriteLine(c2);  // 5i + 7
         }

         {
            Pet pet = new Pet("Lola");
            Dog dog = new Dog("Rex", "black");

            Pet cpet = pet.Clone();
            Dog ddog = dog.Clone();

            // Pet another = new Dog("Dark", "white");
            // Dog copy = another.Clone(); // ERROR this methods returns a Pet 
         }
      }
   }
}
