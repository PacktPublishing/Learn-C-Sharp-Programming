using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Reflection;

namespace chapter_11_04
{
   class Program
   {
      static void Main(string[] args)
      {
         {
            dynamic i = 42;
            dynamic s = "42";
            dynamic d = 42.0;
            dynamic l = new List<int> { 42 };

            l.Add(43);  // OK

            try
            {
               s.Add(44);  // runtime exception
                           // RuntimeBinderException: 'string' does not contain a definition for 'Add'
            }
            catch (Exception ex)
            {
               Console.WriteLine(ex.Message);
            }
         }

         {
            var assembly = Assembly.LoadFrom("EngineLib.dll");

            if (assembly != null)
            {
               var type = assembly.GetType("EngineLib.Engine");

               dynamic engine = Activator.CreateInstance(
                   type,
                   new object[] { "M270 Turbo", 1600, 75.0 });

               Console.WriteLine(engine.Status);
               engine.Start();
               Console.WriteLine(engine.Status);
            }
         }

         {
            dynamic excel = Activator.CreateInstance(
                Type.GetTypeFromProgID("Excel.Application.16"));
            if (excel != null)
            {
               excel.Visible = true;

               dynamic workBook = excel.Workbooks.Add();
               dynamic workSheet = excel.ActiveWorkbook.ActiveSheet;

               workSheet.Cells[1, 1] = "ID";
               workSheet.Cells[1, 2] = "Name";
               workSheet.Cells[2, 1] = "1";
               workSheet.Cells[2, 2] = "One";
               workSheet.Cells[3, 1] = "2";
               workSheet.Cells[3, 2] = "Two";

               workBook.SaveAs("d:\\demo.xls",
                               Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal,
                               AccessMode: Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive);

               workBook.Close(true);
               excel.Quit();
            }
         }
      }
   }
}
