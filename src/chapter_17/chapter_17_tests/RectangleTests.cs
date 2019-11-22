using chapter_17_lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace chapter_17_tests
{
   [TestClass]
   public class RectangleTests
   {
      [TestMethod]
      public void TestEmpty()
      {
         var rectangle = Rectangle.Empty;
         Assert.AreEqual(0, rectangle.Left);
         Assert.AreEqual(0, rectangle.Top);
         Assert.AreEqual(0, rectangle.Right);
         Assert.AreEqual(0, rectangle.Bottom);
      }

      [TestMethod]
      public void TestConstructor()
      {
         var rectangle = new Rectangle(1, 2, 3, 4);
         Assert.AreEqual(1, rectangle.Left);
         Assert.AreEqual(2, rectangle.Top);
         Assert.AreEqual(3, rectangle.Right);
         Assert.AreEqual(4, rectangle.Bottom);
      }

      [TestMethod]
      public void TestProperties()
      {
         var rectangle = new Rectangle(1, 2, 3, 4);
         Assert.AreEqual(2, rectangle.Width, "With must be 2");
         Assert.AreEqual(2, rectangle.Height, "Height must be 2");
         Assert.AreEqual(4, rectangle.Area, "Area must be 4");
      }

      [TestMethod]
      public void TestPropertiesMore()
      {
         var rectangle = new Rectangle(1, 2, -3, -4);
         Assert.IsTrue(rectangle.Width < 0, "Width should be negative");
         Assert.IsFalse(rectangle.Height > 0, "Height should be negative");
      }
   }
}
