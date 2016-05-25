using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using StatueApp.Annotations;
using StatueApp.Model;

namespace StatueApp.Common
{
    public class StatueSingleton : INotifyPropertyChanged
    {
        /// Properties
        /// 
        #region Properties
        public modelDescription Description { get; set; }
        public modelGPSLocation GpsLocation { get; set; }
        public modelStatue Statue { get; set; }
        public modelStatue SelectedStatue { get; set; }

        public ObservableCollection<modelImage> Images { get; set; }
        public ObservableCollection<modelMaterial> Materials { get; set; }
        public ObservableCollection<modelPlacement> Placements { get; set; }
        public ObservableCollection<modelStatueType> StatueTypes { get; set; }
        public ObservableCollection<modelCulturalValue> CulturalValues { get; set; }
        #endregion

        /// <summary>
        /// Backing Field til Instance
        /// </summary>
        #region Singleton
        private static StatueSingleton _instance;

        /// <summary>
        /// Sætter instancen af Singletonen udfra om den er initialiseret elle ikke.
        /// </summary>
        /// 
        /// public static SampleSingleton Instance
        /// {
        ///     get
        ///     {
        ///         if (_instance == null)
        ///         {
        ///             _instance = new SampleSingleton();
        ///         }
        ///         return _instance;
        ///     }
        /// }
        /// 
        /// Gør det samme som ovenstående kode
        public static StatueSingleton Instance => _instance ?? (_instance = new StatueSingleton());

        /// <summary>
        /// Constructor der assginer værdier, typer og Collections til klassens properties
        /// </summary>
        private StatueSingleton() // Default Constructor
        {
            Statue = new modelStatue();
            SelectedStatue = new modelStatue();
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
        /// <summary>
        /// Nulstiller værdierne i Singletonen
        /// </summary>
        public void Dispose()
        {
            _instance.Statue = new modelStatue();
            _instance.SelectedStatue = new modelStatue();
            _instance.Description = new modelDescription();
            _instance.GpsLocation = new modelGPSLocation();
            _instance.CulturalValues.Clear();
            _instance.Images.Clear();
            _instance.Materials.Clear();
            _instance.Placements.Clear();
            _instance.StatueTypes.Clear();
        }
    }
}
