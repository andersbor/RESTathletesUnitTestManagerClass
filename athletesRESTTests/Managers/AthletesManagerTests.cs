using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using athleteLibrary;

namespace athletesREST.Managers.Tests
{
    [TestClass]
    public class AthletesManagerTests
    {
        [TestMethod]
        public void TestItAll()
        {
            AthletesManager manager = new AthletesManager();
            IEnumerable<Athlete> athletes = manager.GetAll();
            Assert.AreEqual(5, athletes.Count());

            athletes = manager.GetAll(country: "Denmark");
            Assert.AreEqual(2, athletes.Count());
            Assert.IsTrue(2 == athletes.Count());
            // Assert.IsTrue: Shows no info if the test fails.
            // Assert.AreEquals: Shows expected and actual values if test fails

            Athlete a = new Athlete { Name = "Carl L", Country = "USA", Height = 190 };
            Athlete ath = manager.Add(a);
            Assert.AreEqual("Carl L", ath.Name);

            Athlete b = manager.Delete(ath.Id);
            Assert.AreEqual("Carl L", b.Name);

            Assert.IsNull(manager.Delete(ath.Id));
        }

    }
}