using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using StatueApp.Annotations;
using StatueApp.Facade;
using StatueApp.Model;


namespace StatueApp.ViewModel
{
    public class ViewModelCreateStatue: INotifyPropertyChanged
    {
        private static ObservableCollection<modelMaterial> _statueMaterialStone;

        #region Properties
        public static ObservableCollection<modelStatueType> StatueType { get; set; }
        public static ObservableCollection<modelPlacement> StatuePlacement  { get; set; } 
        public static ObservableCollection<modelCulturalValue> CulturalValues { get; set; } 
        public static ObservableCollection<modelImage> StatueImage { get; set; } 
        public static ObservableCollection<modelMaterial> StatueMaterial { get; set; }

        public static ObservableCollection<modelMaterial> StatueMaterialStone => GetSpecificMaterialList("S");
        public static ObservableCollection<modelMaterial> StatueMaterialMetal => GetSpecificMaterialList("M");
        public static ObservableCollection<modelMaterial> StatueMaterialOther => GetSpecificMaterialList("A");
        #endregion

        #region Constructors
        public ViewModelCreateStatue()
        {
            ////Henter singleton ned så den kan bruges i meotderne
            //StatueTypeSingleton = StatueTypeSingleton.Instance;
            ////Skyder metoden så den bruges
            //GetStatueTypeAsync();

            ////Henter singleton ned så den kan bruges i meotderne
            //PlacementSingleton = PlacmentSingleton.Instance;
            ////Skyder metoden så den bruges
            //GetStatuePlacementAsync();
            StatueType = new ObservableCollection<modelStatueType>();
            GetStatueTypeAsync();

            StatuePlacement = new ObservableCollection<modelPlacement>();
            GetStatuePlacementAsync();

            CulturalValues = new ObservableCollection<modelCulturalValue>();
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
        /// <param name="c">Materiale Type</param>
        /// <returns>ObservableCollection of modelMaterial</returns>
        public static ObservableCollection<modelMaterial> GetSpecificMaterialList(string c)
        {
            var MaterialList = new ObservableCollection<modelMaterial>();
            foreach (var material in StatueMaterial)
            {
                if (string.Equals(material.Types, c, StringComparison.CurrentCultureIgnoreCase))
                {
                    MaterialList.Add(material);
                }
            }
            return MaterialList;
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

        public async void GetCulturalValueAsync()
        {
            var listOfCulturalValue = await facadeStatue.GetListAsync(new modelCulturalValue());
            foreach (var culturalValues in listOfCulturalValue)
            {
                CulturalValues.Add(culturalValues);
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
