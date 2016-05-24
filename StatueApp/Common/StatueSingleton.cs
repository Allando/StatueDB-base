using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using StatueApp.Annotations;
using StatueApp.Model;

namespace StatueApp.Common
{
    public class StatueSingleton : INotifyPropertyChanged//, IDisposable
    {
        // Properties
        #region Properties
        public modelDescription Description { get; set; }
        public modelGPSLocation GpsLocation { get; set; }
        public modelStatue Statue { get; set; }
        #endregion

        // OCs
        #region Observable Collection
        public ObservableCollection<modelImage> Images { get; set; }
        public ObservableCollection<modelMaterial> Materials { get; set; }
        public ObservableCollection<modelPlacement> Placements { get; set; }
        public ObservableCollection<modelStatueType> StatueTypes { get; set; }
        public ObservableCollection<modelCulturalValue> CulturalValues { get; set; }
        #endregion

        #region Singleton
        private static StatueSingleton _instance;

        public static StatueSingleton Instance
        {
            get { return _instance ?? (_instance = new StatueSingleton()); }
        }

        //public void Dispose()
        //{
        //    _instance.Dispose();
        //}

        private StatueSingleton()
        {
            Statue = new modelStatue();
            CulturalValues = new ObservableCollection<modelCulturalValue>();
            Images = new ObservableCollection<modelImage>();
            Materials = new ObservableCollection<modelMaterial>();
            Placements = new ObservableCollection<modelPlacement>();
            StatueTypes = new ObservableCollection<modelStatueType>();
        }
        #endregion

        #region PropertyChanged Support
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

    }
}
