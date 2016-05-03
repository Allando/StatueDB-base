using System;
using StatueApp.Common;

namespace StatueApp.Handler
{
    class handlerStatue
    {


        /// <summary>
        /// Denne Metode henter alle de Objecter som vores DropDownMeny i OpretStatue Skal Bruge.
        /// Dette gør den hved at kalde andre mindre metoder
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







    }
}
