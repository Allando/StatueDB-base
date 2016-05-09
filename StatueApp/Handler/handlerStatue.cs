using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Windows.ApplicationModel.Appointments;
using Newtonsoft.Json.Linq;
using StatueApp.Common;
using StatueApp.Facade;
using StatueApp.Model;

namespace StatueApp.Handler
{
    class handlerStatue
    {
        /// <summary>
        /// Denne Metode henter alle de Objecter som vores DropDownMenu i OpretStatue Skal Bruge.
        /// Dette gør den bland andet ved at kalde andre mindre metoder
        /// </summary>
        public static void Get_Info()
        {
            StatueSingleton Singleton = StatueSingleton.Instance;
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


        public async static Task<string> Opretstatue()
        {
            StatueSingleton Singleton = StatueSingleton.Instance;
            ObservableCollection<modelCulturalValueList> culturalValueLists = new ObservableCollection<modelCulturalValueList>();
            ObservableCollection<modelImageList> imageLists = new ObservableCollection<modelImageList>();
            ObservableCollection<modelMaterialList> materialLists = new ObservableCollection<modelMaterialList>();
            ObservableCollection<Model.modelPlacementList> placementLists = new ObservableCollection<modelPlacementList>();
            ObservableCollection<Model.modelStatueTypeList> statueTypeLists = new ObservableCollection<modelStatueTypeList>();



            Task<IEnumerable<modelStatue>> Statues = facadeStatue.GetListAsync(new modelStatue());
            
           modelStatue StatueMedId = new modelStatue();
            StatueMedId.Id = 0;

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
                    modelCulturalValueList culturalValueList = new modelCulturalValueList();
                    culturalValueList.FK_CulturalValue = culturalValue.Id;
                    culturalValueList.FK_Statue = StatueMedId.Id;
                    culturalValueLists.Add(culturalValueList);
                }
                foreach (var image in Singleton.Images)
                {
                    modelImageList imageList = new modelImageList();
                    imageList.FK_Image = image.Id;
                    imageList.FK_Statue = StatueMedId.Id;
                    imageLists.Add(imageList);

                }
                foreach (var material in Singleton.Materials)
                {
                    modelMaterialList materialList = new modelMaterialList();
                    materialList.FK_Material = material.Id;
                    materialList.FK_Statue = StatueMedId.Id;
                    materialLists.Add(materialList);
                }
                foreach (var placement in Singleton.Placements)
                {
                    modelPlacementList placementList = new modelPlacementList();
                    placementList.FK_Placement = placement.Id;
                    placementList.FK_Statue = StatueMedId.Id;
                    placementLists.Add(placementList);
                }
                foreach (var statueType in Singleton.StatueTypes)
                {
                    modelStatueTypeList statueTypeList = new modelStatueTypeList();
                    statueTypeList.FK_StatueType = statueType.Id;
                    statueTypeList.FK_Statue = StatueMedId.Id;
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
                catch (Exception)
                {
                    
                    throw;
                }

            }
            catch (Exception)
            {
                
                throw;
            }  
           

         



            // jeg laver denne if da det ikke er sikkert at der er et billed


            //Temp Er bare så den kan builde mens jeg laver metoden
            string temp = "Hej";
            return temp;
        }


    }
}
