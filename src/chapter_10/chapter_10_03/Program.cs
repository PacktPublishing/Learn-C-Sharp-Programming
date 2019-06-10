using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace chapter_10_03
{
   public class Form
   {
      public Form() { }
   }

   public delegate void ControlEvent(object sender, EventArgs args);

   public class Button
   {
      public event ControlEvent Click;
   }

   public partial class MyForm : Form
   {
      private Button myButton = new Button();

      private void InitializeComponent() { }
   }

   public partial class MyForm : Form
   {
      public MyForm()
      {
         InitializeComponent();

         myButton.Click += async (sender, e) =>
         {
            await ExampleMethodAsync();
         };
      }

      private async Task ExampleMethodAsync()
      {
         // a time-consuming action
         await Task.Delay(1000);
      }
   }

   class Foo
   {
      public int Data { get; private set; }

      public Foo(int value)
      {
         Data = value;
      }

      public void Scramble(int value, int iterations)
      {
         Func<int, int> apply = (i) => Data ^ i + value;
         for (int i = 0; i < iterations; ++i)
            Data = apply(i);
      }
   }

   class Program
   {
      static void Main(string[] args)
      {
         {
            bool IsOdd(int x) { return x % 2 == 1; }
            var list = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            list.RemoveAll(IsOdd);
         }

         {
            var list = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            list.RemoveAll(delegate (int x) { return x % 2 == 1; });
         }

         {
            var list = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            list.RemoveAll(x => x % 2 == 1);
         }

         {
            var list = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            list.RemoveAll(x => { return x % 2 == 1; });
         }

         {
            var f = new Foo(42);
            f.Scramble(991, 13);
            Console.WriteLine(f.Data);
         }
      }
   }
}
