using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StatueApp.Model;

namespace StatueApp.Common
{
    public class StatueSingleton
    {
#region Properties
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
        public ObservableCollection<modelMaterial> All_Materials { get; }
        public ObservableCollection<string> Materialtypes { get; }
        public ObservableCollection<modelMaterial> Maeterial_By_Type { get; }
        public ObservableCollection<modelPlacement> Placements { get; }
        public ObservableCollection<modelStatueType> StatueTypes; 
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
    }
}
