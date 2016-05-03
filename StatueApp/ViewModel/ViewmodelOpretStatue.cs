using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StatueApp.Common;

namespace StatueApp.ViewModel
{
    class ViewmodelOpretStatue
    {
       public StatueSingleton Singleton { get; }
        public string selectedtype;


        private RelayCommand MaterialetypeCommand;



        public ViewmodelOpretStatue()
        {
            MaterialetypeCommand = new RelayCommand(MaterialByTypeSortment);
            Singleton = StatueSingleton.Instance;
        }

        /// <summary>
        /// Denne Metode Laver En Observable Collection Kun Med De Materiels Som Er Af Den Type Som Bruger Har Valgt
        /// </summary>
        public void MaterialByTypeSortment()
        {
            foreach (var Material in Singleton.All_Materials)
            {
                if(Material.Types == selectedtype)
                {
                    Singleton.Maeterial_By_Type.Add(Material);
                }
                
            }
        }
    }
}
