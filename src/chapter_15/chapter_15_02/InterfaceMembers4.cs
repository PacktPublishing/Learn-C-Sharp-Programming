using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace chapter_15_02
{
    [TestClass]
    public class InterfaceMembers4
    {
        [TestMethod]
        public void TestMethod1()
        {
            IDog archie = new Labrador("Archie");
            //Assert.AreEqual("barks", archie.Noise);  // V1
            Assert.AreEqual("woofs", archie.Noise);  // V2
        }

        public interface IDog
        {
            string Name { get; }
            string Noise => "barks";
        }

        public interface ILabrador : IDog
        {
            int RetrieverAbility { get; }
            string IDog.Noise => "woofs";    // V2
        }

        public interface IYellowLabrador : ILabrador
        {
            abstract string IDog.Noise { get; }
        }

        public class YellowLabrador : IYellowLabrador
        {
            public YellowLabrador(string name)
            {
                this.Name = name;
            }

            public string Name { get; }
            public int RetrieverAbility { get; set; }
            public string Noise { get; set; }
        }

        public class Labrador : ILabrador
        {
            public Labrador(string name)
            {
                this.Name = name;
            }

            public string Name { get; }
            public int RetrieverAbility { get; set; }
        }

    }
}
