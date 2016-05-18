using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using StatueApp.Annotations;
using StatueApp.Common;
using StatueApp.Facade;
using StatueApp.Model;


namespace StatueApp.ViewModel
{
    public class ViewModelCreateStatue : INotifyPropertyChanged
    {
        #region Properties

        public StatueSingleton NewStatue { get; set; }

        public static ObservableCollection<modelStatueType> StatueType { get; set; }
        public static ObservableCollection<modelPlacement> StatuePlacement { get; set; }
        public static ObservableCollection<modelCulturalValue> CulturalValue { get; set; }
        public static ObservableCollection<modelImage> StatueImage { get; set; }
        public static ObservableCollection<modelMaterial> StatueMaterial { get; set; }

        public static ObservableCollection<modelMaterial> StatueMaterialStone { get; set; }
        public static ObservableCollection<modelMaterial> StatueMaterialMetal { get; set; }
        public static ObservableCollection<modelMaterial> StatueMaterialOther { get; set; }
        #endregion

        #region Constructors
        public ViewModelCreateStatue()
        {
            NewStatue = StatueSingleton.Instance;

            StatueType = new ObservableCollection<modelStatueType>();
            GetStatueTypeAsync();

            StatuePlacement = new ObservableCollection<modelPlacement>();
            GetStatuePlacementAsync();

            CulturalValue = new ObservableCollection<modelCulturalValue>();
            GetCulturalValueAsync();

            StatueImage = new ObservableCollection<modelImage>();
            GetStatueImageAsync();

            StatueMaterial = new ObservableCollection<modelMaterial>();
            GetStatueMaterialAsync();
        }
        #endregion

        #region Methods
        /// <summary>
        /// Genererer en Observable Collection af en Bestemt type Materialer 
        /// </summary>
        /// <param name="s">Materiale Type</param>
        /// <returns>ObservableCollection of modelMaterial</returns>
        public static ObservableCollection<modelMaterial> GetSpecificMaterialList(string s)
        {
            var materialList = new ObservableCollection<modelMaterial>();
            foreach (var material in StatueMaterial)
            {
                if (string.Equals(material.MaterialType, s, StringComparison.CurrentCultureIgnoreCase))
                {
                    materialList.Add(material);
                }
            }
            return materialList;
        }

        /// <summary>
        /// Henter StatueTyper
        /// </summary>
        public async void GetStatueTypeAsync()
        {
            var listOfStatueType = await facadeStatue.GetListAsync(new modelStatueType());
            foreach (var statueType in listOfStatueType)
            {
                StatueType.Add(statueType);
            }
        }

        /// <summary>
        /// Henter StatuePlacering
        /// </summary>
        public async void GetStatuePlacementAsync()
        {
            var listOfStatuePlacement = await facadeStatue.GetListAsync(new modelPlacement());
            foreach (var statuePlacement in listOfStatuePlacement)
            {
                StatuePlacement.Add(statuePlacement);
            }
        }
        /// <summary>
        /// Henter CulturalValue
        /// </summary>
        public async void GetCulturalValueAsync()
        {
            var listOfCulturalValue = await facadeStatue.GetListAsync(new modelCulturalValue());
            foreach (var culturalValue in listOfCulturalValue)
            {
                CulturalValue.Add(culturalValue);
            }
        }

        public async void GetStatueImageAsync()
        {
            var listOfStatueImage = await facadeStatue.GetListAsync(new modelImage());
            foreach (var statueImage in listOfStatueImage)
            {
                StatueImage.Add(statueImage);
            }
        }

        public async void GetStatueMaterialAsync()
        {
            var listOfStatueMaterial = await facadeStatue.GetListAsync(new modelMaterial());
            foreach (var statueMaterial in listOfStatueMaterial)
            {
                StatueMaterial.Add(statueMaterial);
            }

            // Nødvendigt at kalde herfra da Materiale listen eller ikke er klar
            StatueMaterialStone = GetSpecificMaterialList("s");
            StatueMaterialMetal = GetSpecificMaterialList("m");
            StatueMaterialOther = GetSpecificMaterialList("a");
        }
        #endregion

        #region PropertyChangedSupport
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
