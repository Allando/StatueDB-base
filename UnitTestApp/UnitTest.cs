using System;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using StatueApp.SampleCode;
using StatueApp.Model;

namespace UnitTestApp
{
    [TestClass]
    public class UnitTestApp
    {
        [TestMethod]
        public void TestGenericGet()
        {
            modelStatue result = new modelStatue();

            result = Facade.GetItemAsync<modelStatue>(5).Result;

            Assert.AreEqual(5,result.Id);
        }
    }
}
