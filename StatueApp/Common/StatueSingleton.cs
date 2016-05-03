using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using StatueApp.Annotations;
using StatueApp.Model;

namespace StatueApp.Common
{
    public class StatueSingleton : INotifyPropertyChanged
    {
        #region Properties
        // de her properties er dem som bliver bindet til "Text" i textboxe og "Selectet Item" I dropdown Menuer
        public modelCulturalValue CulturalValue { get; set; }
        public modelDescription Description { get; set; }
        public modelGPSLocation GpsLocation { get; set; }
        public modelImage Image { get; set; }
        public modelMaterial Material { get; set; }
        public modelPlacement Placement { get; set; }
        public modelStatue Statue { get; set; }
        public modelStatueType StatueType { get; set; }
        public modelZipcode Zipcode { get; set; }
        #endregion

        #region Collections
        // de her collections bliver brugt til at fylde dropdown Menuerne"
        public ObservableCollection<modelMaterial> All_Materials { get; }
        public ObservableCollection<string> Materialtypes { get; }
        public ObservableCollection<modelMaterial> Maeterial_By_Type { get; }
        public ObservableCollection<modelPlacement> Placements { get; }
        public ObservableCollection<modelStatueType> StatueTypes { get; }
        #endregion

        #region Singleton
        private static StatueSingleton _instance;
        public static StatueSingleton Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new StatueSingleton();
                }
                return _instance;
            }
        }

#endregion
        private StatueSingleton()
        {
            All_Materials = new ObservableCollection<modelMaterial>();
            Maeterial_By_Type = new ObservableCollection<modelMaterial>();
            Materialtypes = new ObservableCollection<string>();
            StatueTypes = new ObservableCollection<modelStatueType>();
            Placements = new ObservableCollection<modelPlacement>();
        }
        #region Property Changed
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
