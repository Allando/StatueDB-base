using System;
using StatueApp.Model;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace UnitTestViewModelStatue
{
    [TestClass]
    public class UnitTest1
    {

        private modelStatue _statue;


        [TestInitialize]
        public void Before()
        {
            _statue = new modelStatue(5, "TestStatue", "Elisagaardsvej 5 4000 Roskilde", "4000", DateTime.Now, DateTime.Now); 
        }

        [TestMethod]
        public void TestGetStatueMethod()
        {
            
        }
    }
}
