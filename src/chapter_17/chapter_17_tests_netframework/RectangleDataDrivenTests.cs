using System;
using System.Collections.Generic;
using chapter_17_lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace chapter_17_tests_netframework
{
   [TestClass]
   public class RectangleDataDrivenTests
   {
      private static TestContext _tc;

      [ClassInitialize]
      public static void Initialization(TestContext testContext)
      {
         _tc = testContext;
      }

      [DataTestMethod]
      [DataRow(true, 3, 4, 5, 6)]
      [DataRow(true, 5, 10, 20, 13)]
      [DataRow(false, 11, 13, 15, 16)]
      public void TestIntersectsWith_DataRows(bool result, int left, int top, int right, int bottom)
      {
         var rectangle = new Rectangle(1, 2, 10, 12);

         Assert.AreEqual(
            result,
            rectangle.IntersectsWith(
               new Rectangle(left, top, right, bottom)));
      }

      public static IEnumerable<object[]> GetData()
      {
         yield return new object[] { true, 3, 4, 5, 6 };
         yield return new object[] { true, 5, 10, 20, 13 };
         yield return new object[] { false, 11, 13, 15, 16 };
      }

      [DataTestMethod]
      [DynamicData(nameof(GetData), DynamicDataSourceType.Method)]
      public void TestIntersectsWith_DynamicData(bool result, int left, int top, int right, int bottom)
      {
         var rectangle = new Rectangle(1, 2, 10, 12);

         Assert.AreEqual(
            result,
            rectangle.IntersectsWith(
               new Rectangle(left, top, right, bottom)));
      }

      [DataTestMethod]
      [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV",
                  "TestData.csv",
                  "TestData#csv",
                  DataAccessMethod.Sequential)]
      public void TestIntersectsWith_CsvData()
      {
         var rectangle = new Rectangle(1, 2, 10, 12);

         bool result = Convert.ToBoolean(_tc.DataRow["Expected"]);
         int left = Convert.ToInt32(_tc.DataRow["left"]);
         int top = Convert.ToInt32(_tc.DataRow["top"]);
         int right = Convert.ToInt32(_tc.DataRow["right"]);
         int bottom = Convert.ToInt32(_tc.DataRow["bottom"]);

         Assert.AreEqual(
            result,
            rectangle.IntersectsWith(
               new Rectangle(left, top, right, bottom)));
      }
   }
}
