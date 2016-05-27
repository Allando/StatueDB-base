using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using StatueApp.Common;
using StatueApp.Facade;
using StatueApp.Handler;
using StatueApp.Model;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace StatueAppTest
{
    [TestClass]
    internal class HandlerTestClass
    {
        [TestMethod]
        public void TestGetListMethod()
        {
            StatueSingleton singleton = StatueSingleton.Instance;
            singleton.Statue.Name = "carsten";
            singleton.Statue.Address = "rampelyset 12";
            singleton.Statue.Zipcode = "1234";
            var culturalvalues = facadeStatue.GetListAsync(new modelCulturalValue()).Result;
            var materials = facadeStatue.GetListAsync(new modelMaterial()).Result;
            var placements = facadeStatue.GetListAsync(new modelPlacement()).Result;
            var statuetypes = facadeStatue.GetListAsync(new modelStatueType()).Result;
            singleton.CulturalValues.Add(culturalvalues.ElementAt(2));
            singleton.Materials.Add(materials.ElementAt(5));
            singleton.Placements.Add(placements.ElementAt(1));
            singleton.StatueTypes.Add(statuetypes.ElementAt(2));



           handlerStatue.CreateStatue();

            for (int i = 0; i < 10000000; i++)
            {
               int x = 2 + 2;
            }

            var statueList = facadeStatue.GetListAsync(new modelStatue()).Result;

            modelStatue neweststatue = new modelStatue();

            foreach (modelStatue statue in statueList)
            {
                if (statue.Id > neweststatue.Id)
                {
                    neweststatue = statue;
                }
            }

            var culturalvalue = facadeStatue.GetByStatueIdAsync(new modelCulturalValueList(), neweststatue.Id).Result;
            var material = facadeStatue.GetByStatueIdAsync(new modelMaterialList(), neweststatue.Id).Result;
            var placement = facadeStatue.GetByStatueIdAsync(new modelPlacementList(), neweststatue.Id).Result;
            var statuetype = facadeStatue.GetByStatueIdAsync(new modelStatueTypeList(), neweststatue.Id).Result;

            Assert.AreEqual(neweststatue.Name, "carsten");
            Assert.AreEqual(neweststatue.Address, "rampelyset 12");
            Assert.AreEqual(neweststatue.Zipcode, "1234");
            Assert.AreEqual(culturalvalue.First().FK_CulturalValue, culturalvalues.First().Id);
            Assert.AreEqual(material.First().FK_Material, materials.First().Id);
            Assert.AreEqual(placement.First().FK_Placement, placements.First().Id);
            Assert.AreEqual(statuetype.First().FK_StatueType, statuetypes.First().Id);




            facadeStatue.DeleteAsync(new modelCulturalValueList(), culturalvalue.First().Id);
            facadeStatue.DeleteAsync(new modelMaterialList(), material.First().Id);
            facadeStatue.DeleteAsync(new modelPlacementList(), placement.First().Id);
            facadeStatue.DeleteAsync(new modelStatueTypeList(), statuetype.First().Id);
            facadeStatue.DeleteAsync(new modelStatue(), neweststatue.Id);


        }

    }
}
