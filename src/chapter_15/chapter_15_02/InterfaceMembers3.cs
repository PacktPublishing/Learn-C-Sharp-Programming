using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace chapter_15_02
{
    [TestClass]
    public class InterfaceMembers3
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
