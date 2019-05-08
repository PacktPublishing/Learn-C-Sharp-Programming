using System;

namespace chapter_09_05
{
   unsafe struct Node
   {
      public int   Value;
      public Node* Left;
      public Node* Right;
   }

   struct Node2
   {
      public int           Value;
      public unsafe Node2* Left;
      public unsafe Node2* Right;
   }

   class Color
   {
      public byte Alpha;
      public byte Red;
      public byte Green;
      public byte Blue;

      public Color(byte a, byte r, byte g, byte b)
      {
         Alpha = a;
         Red = r;
         Green = g;
         Blue = b;
      }
   }

   class Program
   {
      static unsafe void Increment(int* value)
      {
         *value += 1;
      }

      static void SetTransparency(Color color, double value)
      {
         unsafe
         {
            fixed (byte* alpha = &color.Alpha)
            {
               *alpha = (byte)(value * 255);
            }
         }
      }

      static unsafe void AllocArrayExample(int size)
      {
         int* arr = stackalloc int[size];
         for (int i = 1; i <= size; ++i)
            arr[i] = i;
      }

      static void SizeOfExample()
      {
         unsafe
         {
            Console.WriteLine($"Pointer size: {sizeof(int*)}");
         }
      }

      static void Main(string[] args)
      {
         int value = 42;
         unsafe
         {
            int* p = &value;
            *p += 1;
         }
         Console.WriteLine(value);

         unsafe
         {
            Increment(&value); // OK
         }

         // Increment(&value);    // error

         Color color = new Color(255, 255, 0, 0);
         SetTransparency(color, .5);

         unsafe
         {
            AllocArrayExample(32);
         }

         SizeOfExample();
      }
   }
}
