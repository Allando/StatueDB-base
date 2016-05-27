using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using StatueApp.Common;
using StatueApp.Facade;
using StatueApp.Handler;
using StatueApp.Model;

namespace StatueAppTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public async Task Createstatuetest()
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


            await handlerStatue.CreateStatue();


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

            Assert.AreEqual("carsten", neweststatue.Name);
            Assert.AreEqual("rampelyset 12", neweststatue.Address);
            Assert.AreEqual("1234", neweststatue.Zipcode);
            Assert.AreEqual(3, culturalvalue.First().FK_CulturalValue);
            Assert.AreEqual(6, material.First().FK_Material);
            Assert.AreEqual(2, placement.First().FK_Placement);
            Assert.AreEqual(3, statuetype.First().FK_StatueType);

        


            facadeStatue.DeleteAsync(new modelCulturalValueList(), culturalvalue.First().Id);
            facadeStatue.DeleteAsync(new modelMaterialList(), material.First().Id);
            facadeStatue.DeleteAsync(new modelPlacementList(), placement.First().Id);
            facadeStatue.DeleteAsync(new modelStatueTypeList(), statuetype.First().Id);
           await facadeStatue.DeleteAsync(new modelStatue(), neweststatue.Id);
        }
    }
}
