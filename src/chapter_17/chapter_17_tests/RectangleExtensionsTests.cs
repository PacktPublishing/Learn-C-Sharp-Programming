using chapter_17_lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace chapter_17_tests
{
   [TestClass]
   public class RectangleExtensionsTests
   {
      [TestMethod]
      public void TestInflate()
      {
         var rectangle1 = Rectangle.Empty.Inflate(1, 2, 3, 4);
         Assert.AreEqual(1, rectangle1.Left);
         Assert.AreEqual(2, rectangle1.Top);
         Assert.AreEqual(3, rectangle1.Right);
         Assert.AreEqual(4, rectangle1.Bottom);

         var rectangle2 = Rectangle.Empty.Inflate(-1, -2, -3, -4);
         Assert.AreEqual(-1, rectangle2.Left);
         Assert.AreEqual(-2, rectangle2.Top);
         Assert.AreEqual(-3, rectangle2.Right);
         Assert.AreEqual(-4, rectangle2.Bottom);
      }

      [TestMethod]
      public void TestDeflate()
      {
         var rectangle1 = Rectangle.Empty.Deflate(1, 2, 3, 4);
         Assert.AreEqual(-1, rectangle1.Left);
         Assert.AreEqual(-2, rectangle1.Top);
         Assert.AreEqual(-3, rectangle1.Right);
         Assert.AreEqual(-4, rectangle1.Bottom);

         var rectangle2 = Rectangle.Empty.Deflate(-1, -2, -3, -4);
         Assert.AreEqual(1, rectangle2.Left);
         Assert.AreEqual(2, rectangle2.Top);
         Assert.AreEqual(3, rectangle2.Right);
         Assert.AreEqual(4, rectangle2.Bottom);
      }

      [TestMethod]
      public void TestIntersectsWith()
      {
         var rectangle = new Rectangle(1, 2, 10, 12);
         var rectangle1 = new Rectangle(3, 4, 5, 6);
         var rectangle2 = new Rectangle(5, 10, 20, 13);
         var rectangle3 = new Rectangle(11, 13, 15, 16);

         Assert.IsTrue(rectangle.IntersectsWith(rectangle1));
         Assert.IsTrue(rectangle.IntersectsWith(rectangle2));
         Assert.IsFalse(rectangle.IntersectsWith(rectangle3));
      }

      [TestMethod]
      public void TestIntersect()
      {
         var rectangle = new Rectangle(1, 2, 10, 12);
         var rectangle1 = new Rectangle(3, 4, 5, 6);
         var rectangle2 = new Rectangle(5, 10, 20, 13);
         var rectangle3 = new Rectangle(11, 13, 15, 16);

         var intersection1 = rectangle.Intersect(rectangle1);
         var intersection2 = rectangle.Intersect(rectangle2);
         var intersection3 = rectangle.Intersect(rectangle3);

         Assert.AreEqual(3, intersection1.Left);
         Assert.AreEqual(4, intersection1.Top);
         Assert.AreEqual(5, intersection1.Right);
         Assert.AreEqual(6, intersection1.Bottom);

         Assert.AreEqual(5, intersection2.Left);
         Assert.AreEqual(10, intersection2.Top);
         Assert.AreEqual(10, intersection2.Right);
         Assert.AreEqual(12, intersection2.Bottom);

         Assert.AreEqual(0, intersection3.Left);
         Assert.AreEqual(0, intersection3.Top);
         Assert.AreEqual(0, intersection3.Right);
         Assert.AreEqual(0, intersection3.Bottom);
      }
   }
}
