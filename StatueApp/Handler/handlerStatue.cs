using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Windows.ApplicationModel.Appointments;
using Newtonsoft.Json.Linq;
using StatueApp.Common;
using StatueApp.Model;

namespace StatueApp.Handler
{
    class handlerStatue
    {


        /// <summary>
        /// Denne Metode henter alle de Objecter som vores DropDownMeny i OpretStatue Skal Bruge.
        /// Dette gør den bland andet hved at kalde andre mindre metoder
        /// </summary>
        public static void Get_Info()
        {

            StatueSingleton Singleton = StatueSingleton.Instance;
            GetMaterialtypes();
        }

        /// <summary>
        /// Denne Metode Vil Tilføje Alle Materialetyperne Til Listen Materialtypes i Singletonen;
        /// </summary>
        public static void GetMaterialtypes()
        {
            StatueSingleton Singleton = StatueSingleton.Instance;
            foreach (var Material in Singleton.All_Materials)
            {
                if (!Singleton.Materialtypes.Contains(Material.Types))
                {
                    Singleton.Materialtypes.Add(Material.Types);
                }

            }
        }

        /// <summary>
        /// Denne Metode Vil Oprette En Statue Og Gemme Den I Databasen
        /// </summary>
        /// <returns> Fejlbesked Eller Sysesbesked </returns>
        public static string Opretstatue()
        {
            StatueSingleton Singleton = StatueSingleton.Instance;
            modelCulturalValueList modelCulturalValueList = new modelCulturalValueList();
            modelImageList modelImageList = new modelImageList();
            modelMaterialList materialList = new modelMaterialList();
            modelPlacementList modelPlacementList = new modelPlacementList();
            modelStatueTypeList modelStatueTypeList = new modelStatueTypeList();

            // her skal du sette alle statueiderne på listerne

            modelStatueTypeList.FK_StatueType = Singleton.StatueType.Id;
            modelPlacementList.FK_Placement = Singleton.Placement.Id;
            materialList.FK_Material = Singleton.Material.Id;
            modelCulturalValueList.FK_CulturalValue = Singleton.CulturalValue.Id;
            
            // jeg laver denne if da det ikke er sikkert at der er et billed
            if (Singleton.Image != null)
            {
                modelImageList.FK_Image = Singleton.Image.Id;
            }


            //Temp Er bare så den kan builde mens jeg laver metoden
            string temp = "Hej";
            return temp;


        }


        







    }
}
