using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace chapter_17_tests
{
   [TestClass]
   public class UnitTestsClass
   {
      [AssemblyInitialize]
      public static void AssemblyInit(TestContext context)
      {
         context.WriteLine("Assembly init...");
      }

      [AssemblyCleanup]
      public static void AssemblyCleanup()
      {
      }

      [ClassInitialize]
      public static void TestFixtureSetup(TestContext context)
      {
         context.WriteLine("Fixture setup...");
      }

      [ClassCleanup]
      public static void TestFixtureTearDown()
      {
      }

      [TestInitialize]
      public void Setup()
      {         
      }

      [TestCleanup]
      public void TearDown()
      {         
      }
      
      [TestMethod]
      public void TestMethod1()
      {         
      }

      [TestMethod]
      public void TestMethod2()
      {
      }
   }
}
