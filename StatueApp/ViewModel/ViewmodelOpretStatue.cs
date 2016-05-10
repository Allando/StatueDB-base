using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using StatueApp.Annotations;
using StatueApp.Common;

namespace StatueApp.ViewModel
{
    class ViewmodelOpretStatue :INotifyPropertyChanged
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
        #region Propety Changed
                public event PropertyChangedEventHandler PropertyChanged;

                [NotifyPropertyChangedInvocator]
                protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
                {
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
                }
        #endregion
    }
}
