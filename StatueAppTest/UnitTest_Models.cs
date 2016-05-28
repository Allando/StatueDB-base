using System;
using StatueApp.Model;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace StatueAppTest
{
    [TestClass]
    public class UnitTest_Models
    {
        [TestInitialize]
        [TestMethod]
        public void TestGetStatueMethod()
        {
            var teststatue = new modelStatue(4, "TestStatue", "Elisagaardsvej 5 4000 Roskilde", "4000", DateTime.Now, DateTime.Now);

            Assert.AreEqual(teststatue.Id, teststatue.Id);
            Assert.AreEqual(teststatue.Name, teststatue.Name);
            Assert.AreEqual(teststatue.Address, teststatue.Address);
            Assert.AreEqual(teststatue.Zipcode, teststatue.Zipcode);
            Assert.AreEqual(teststatue.Created, teststatue.Created);
            Assert.AreEqual(teststatue.Updated, teststatue.Updated);
        }

        [TestMethod]
        public void TestGetStatueMateriale()
        {
            var teststatuemateriale = new modelMaterial(3, "Jern", "m");

            Assert.AreEqual(teststatuemateriale.Id, teststatuemateriale.Id);
            Assert.AreEqual(teststatuemateriale.MaterialName, teststatuemateriale.MaterialName);
            Assert.AreEqual(teststatuemateriale.MaterialType, teststatuemateriale.MaterialType);
        }

        [TestMethod]
        public void TestGetStatueImage()
        {
            var teststatueimage = new modelImage(5, "Url");

            Assert.AreEqual(teststatueimage.Id, teststatueimage.Id);
            Assert.AreEqual(teststatueimage.ImageUrl, teststatueimage.ImageUrl);
        }

        [TestMethod]
        public void TestGetCulturalValue()
        {
            var teststatueculturalvalue = new modelCulturalValue(7, "a");

            Assert.AreEqual(teststatueculturalvalue.Id, teststatueculturalvalue.Id);
            Assert.AreEqual(teststatueculturalvalue.CulturalValueChar, teststatueculturalvalue.CulturalValueChar);
        }

        [TestMethod]
        public void TestStatueGetPlacement()
        {
            var teststatueplacement = new modelPlacement(3, "sokkel");

            Assert.AreEqual(teststatueplacement.Id, teststatueplacement.Id);
            Assert.AreEqual(teststatueplacement.PlacementName, teststatueplacement.PlacementName);
        }

        [TestMethod]
        public void TestGetStatueType()
        {
            var teststatuetype = new modelStatueType(5, "vandkunst");

            Assert.AreEqual(teststatuetype.Id, teststatuetype.Id);
            Assert.AreEqual(teststatuetype.StatueTypeName, teststatuetype.StatueTypeName);
        }

        [TestMethod]
        public void TestGetSpecificMaterialList()
        {
            var testspecificmateriallist = new modelMaterialList(3, 4, 5);

            Assert.AreEqual(testspecificmateriallist.Id, testspecificmateriallist.Id);
            Assert.AreEqual(testspecificmateriallist.FK_Statue, testspecificmateriallist.FK_Statue);
            Assert.AreEqual(testspecificmateriallist.FK_Material, testspecificmateriallist.FK_Material);
        }
    }
}
