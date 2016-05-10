using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using StatueApp.Common;
using StatueApp.Facade;
using StatueApp.Model;

namespace StatueApp.Handler
{
    public class handlerCreateStatue
    {
        /// <summary>
        /// Denne Metode henter alle de Objecter som vores DropDownMenu i OpretStatue Skal Bruge.
        /// Dette gør den bland andet ved at kalde andre mindre metoder
        /// </summary>
        public static void Get_Info()
        {
            //var Singleton = StatueSingleton.Instance;
            //GetMaterialtypes();
        }
        /// <summary>
        /// Denne Metode Vil Tilføje Alle Materialetyperne Til Listen Materialtypes i Singletonen;
        /// </summary>
        //public static void GetMaterialtypes()
        //{
        //    StatueSingleton Singleton = StatueSingleton.Instance;
        //    foreach (var Material in Singleton.All_Materials)
        //    {
        //        if (!Singleton.Materialtypes.Contains(Material.Types))
        //        {
        //            Singleton.Materialtypes.Add(Material.Types);
        //        }
        //    }
        //}
        /// <summary>
        /// Denne Metode Vil Oprette En Statue Og Gemme Den I Databasen
        /// </summary>
        /// <returns> Fejlbesked Eller Sysesbesked </returns>


        public static async Task<string> CreateStatue()
        {
            var Singleton = StatueSingleton.Instance;
            var culturalValueLists = new ObservableCollection<modelCulturalValueList>();
            var imageLists = new ObservableCollection<modelImageList>();
            var materialLists = new ObservableCollection<modelMaterialList>();
            var placementLists = new ObservableCollection<modelPlacementList>();
            var statueTypeLists = new ObservableCollection<modelStatueTypeList>();

            var Statues = facadeStatue.GetListAsync(new modelStatue());

            var StatueMedId = new modelStatue {Id = 0};

            foreach (var statue in Statues.Result)
            {
                if (statue.Id > StatueMedId.Id)
                {
                    StatueMedId = statue;
                }
            }
            try
            {
                await facadeStatue.PostAsync(Singleton.Statue);
                #region ListsID
                // her skal du sette alle statueiderne på listerne
                foreach (var culturalValue in Singleton.CulturalValues)
                {
                    var culturalValueList = new modelCulturalValueList
                    {
                        FK_CulturalValue = culturalValue.Id,
                        FK_Statue = StatueMedId.Id
                    };
                    culturalValueLists.Add(culturalValueList);
                }
                foreach (var image in Singleton.Images)
                {
                    var imageList = new modelImageList
                    {
                        FK_Image = image.Id,
                        FK_Statue = StatueMedId.Id
                    };
                    imageLists.Add(imageList);

                }
                foreach (var material in Singleton.Materials)
                {
                    var materialList = new modelMaterialList
                    {
                        FK_Material = material.Id,
                        FK_Statue = StatueMedId.Id
                    };
                    materialLists.Add(materialList);
                }
                foreach (var placement in Singleton.Placements)
                {
                    var placementList = new modelPlacementList
                    {
                        FK_Placement = placement.Id,
                        FK_Statue = StatueMedId.Id
                    };
                    placementLists.Add(placementList);
                }
                foreach (var statueType in Singleton.StatueTypes)
                {
                    var statueTypeList = new modelStatueTypeList
                    {
                        FK_StatueType = statueType.Id,
                        FK_Statue = StatueMedId.Id
                    };
                    statueTypeLists.Add(statueTypeList);
                }
                #endregion
                try
                {
                    foreach (var culturalValueList in culturalValueLists)
                    {
                        await facadeStatue.PostAsync(culturalValueList);
                    }

                    foreach (var imageList in imageLists)
                    {
                        await facadeStatue.PostAsync(imageList);
                    }
                    foreach (var materialList in materialLists)
                    {
                        await facadeStatue.PostAsync(materialList);
                    }
                    foreach (var placementList in placementLists)
                    {
                        await facadeStatue.PostAsync(placementList);
                    }
                    foreach (var statueTypeList in statueTypeLists)
                    {
                        await facadeStatue.PostAsync(statueTypeList);
                    }
                    if (Singleton.Description != null)
                    {
                        await facadeStatue.PostAsync(Singleton.Description);
                    }
                    if (Singleton.GpsLocation != null)
                    {
                        await facadeStatue.PostAsync(Singleton.GpsLocation);
                    }

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            // jeg laver denne if da det ikke er sikkert at der er et billed
            //Temp Er bare så den kan builde mens jeg laver metoden
            var temp = "Hej";
            return temp;
        }
    }
}
