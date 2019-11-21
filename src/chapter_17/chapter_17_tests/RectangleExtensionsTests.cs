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
         var rectangle = Rectangle.Empty.Inflate(1, 2, 3, 4);
         Assert.AreEqual(1, rectangle.Left);
         Assert.AreEqual(2, rectangle.Top);
         Assert.AreEqual(3, rectangle.Right);
         Assert.AreEqual(4, rectangle.Bottom);
      }
   }
}
