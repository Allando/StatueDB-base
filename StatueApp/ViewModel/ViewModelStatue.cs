using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using StatueApp.Annotations;
using StatueApp.Common;
using StatueApp.Facade;
using StatueApp.Handler;
using StatueApp.Model;
using Windows.UI.Popups;
using StatueApp.View;

namespace StatueApp.ViewModel
{
    public class ViewModelStatue : INotifyPropertyChanged
    {
        #region Properties
        public static StatueSingleton NewStatue { get; set; }
        public static modelStatue SelectedStatue { get; set; }

        public RelayCommand CreateStatueCommand { get; set; }
        public RelayCommand ViewStatueCommand { get; set; }
        public RelayCommand DeleteStatueCommand { get; set; }


        public static ObservableCollection<modelStatueType> StatueType { get; set; }
        public static ObservableCollection<modelPlacement> StatuePlacement { get; set; }
        public static ObservableCollection<modelCulturalValue> CulturalValue { get; set; }
        public static ObservableCollection<modelImage> StatueImage { get; set; }
        public static ObservableCollection<modelMaterial> StatueMaterial { get; set; }

        public static ObservableCollection<modelMaterial> StatueMaterialStone { get; set; }
        public static ObservableCollection<modelMaterial> StatueMaterialMetal { get; set; }
        public static ObservableCollection<modelMaterial> StatueMaterialOther { get; set; }
        public static ObservableCollection<modelStatue> Statues { get; set; }

        private bool _loadingIcon;

        #endregion

        #region Constructors
        public ViewModelStatue()
        {
            NewStatue = StatueSingleton.Instance;
            try
            {
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

                Statues = new ObservableCollection<modelStatue>();
                GetStatueAsync();
            }
            catch (Exception ex)
            {
                ExceptionHandler.ShowExceptionError(ex.Message);
            }

            CreateStatueCommand = new RelayCommand(DoCreateStatue);
            ViewStatueCommand = new RelayCommand(ViewStatue);
            DeleteStatueCommand = new RelayCommand(DoDeleteStatue);
        }
        #endregion

        #region Liste Generatorer
        /// <summary>
        /// Genererer en Observable Collection af en bestemt type Materialer 
        /// </summary>
        /// <param name="materialType">Materiale Type</param>
        /// <returns>ObservableCollection af modelMaterial</returns>
        private static ObservableCollection<modelMaterial> GetSpecificMaterialList(string materialType)
        {
            var materialList = new ObservableCollection<modelMaterial>();
            foreach (var material in StatueMaterial)
            {
                if (string.Equals(material.MaterialType, materialType, StringComparison.CurrentCultureIgnoreCase))
                {
                    materialList.Add(material);
                }
            }
            return materialList;
        }

        /// <summary>
        /// Henter og laver liste over Statue Typer
        /// </summary>
        public async void GetStatueTypeAsync()
        {
            try
            {
                LoadingIcon = true;
                var listOfStatueType = await facadeStatue.GetListAsync(new modelStatueType());
                foreach (var statueType in listOfStatueType)
                {
                    StatueType.Add(statueType);
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.ShowExceptionError(ex.Message);
            }
            finally
            {
                LoadingIcon = false;
            }
        }

        /// <summary>
        /// Henter og laver liste over Statue Placeringer
        /// </summary>
        public async void GetStatuePlacementAsync()
        {
            try
            {
                LoadingIcon = true;
                var listOfStatuePlacement = await facadeStatue.GetListAsync(new modelPlacement());
                foreach (var statuePlacement in listOfStatuePlacement)
                {
                    StatuePlacement.Add(statuePlacement);
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.ShowExceptionError(ex.Message);
            }
            finally
            {
                LoadingIcon = false;
            }
        }

        /// <summary>
        /// Henter og laver liste over Kulturelle Værdier
        /// </summary>
        public async void GetCulturalValueAsync()
        {
            try
            {
                LoadingIcon = false;
                var listOfCulturalValue = await facadeStatue.GetListAsync(new modelCulturalValue());
                foreach (var culturalValue in listOfCulturalValue)
                {
                    CulturalValue.Add(culturalValue);
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.ShowExceptionError(ex.Message);
            }
            finally
            {
                LoadingIcon = false;
            }
        }

        /// <summary>
        /// Henter og laver liste over statue Billeder
        /// </summary>
        public async void GetStatueImageAsync()
        {
            try
            {
                LoadingIcon = true;
                var listOfStatueImage = await facadeStatue.GetListAsync(new modelImage());
                foreach (var statueImage in listOfStatueImage)
                {
                    StatueImage.Add(statueImage);
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.ShowExceptionError(ex.Message);
            }
            finally
            {
                LoadingIcon = false;
            }
        }

        /// <summary>
        /// Henter og laver liste over statue materialler
        /// </summary>
        public async void GetStatueMaterialAsync()
        {
            try
            {
                LoadingIcon = true;
                var listOfStatueMaterial = await facadeStatue.GetListAsync(new modelMaterial());
                foreach (var statueMaterial in listOfStatueMaterial)
                {
                    StatueMaterial.Add(statueMaterial);
                }

                // Nødvendigt at kalde herfra, da Materiale listen ellers ikke er klar
                StatueMaterialStone = GetSpecificMaterialList("s");
                StatueMaterialMetal = GetSpecificMaterialList("m");
                StatueMaterialOther = GetSpecificMaterialList("a");
            }
            catch (Exception ex)
            {
                ExceptionHandler.ShowExceptionError(ex.Message);
            }
            finally
            {
                LoadingIcon = false;
            }
        }

        /// <summary>
        /// Henter og laver liste over statuer
        /// </summary>
        public async void GetStatueAsync()
        {
            Statues.Clear();
            try
            {
                LoadingIcon = true;
                var listOfStatues = await facadeStatue.GetListAsync(new modelStatue());

                foreach (var statue in listOfStatues)
                {
                    Statues.Add(statue);
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.ShowExceptionError(ex.Message);
            }
            finally
            {
                LoadingIcon = false;
            }
        }

        #region Methods
        /// <summary>
        /// Loading Icon
        /// </summary>
        public bool LoadingIcon
        {
            get { return _loadingIcon; }
            set { _loadingIcon = value; OnPropertyChanged(); }
        }

        #endregion

        /// <summary>
        /// Opretter statuen og returnere en besked fra webservicen
        /// </summary>
        public async void DoCreateStatue()
        {
            try
            {
                LoadingIcon = true;
                var msg = await handlerStatue.CreateStatue();
                var message = new MessageDialog(msg);
                await message.ShowAsync();
            }
            catch (Exception ex)
            {
                ExceptionHandler.ShowExceptionError(ex.Message);
            }
            finally
            {
                LoadingIcon = false;
            }
        }

        /// <summary>
        /// Denne metode udfylder properties så man kan se en specifik statue på SeeStatue Viewet + navigere til viewet 
        /// </summary>
        public void ViewStatue()
        {
            try
            {
                NewStatue.SelectedStatue = SelectedStatue;

                // Navigerer til View'et ViewStatue
                NavigationHelper.navigate(typeof(SeeStatue));
            }
            catch (Exception ex)
            {
                ExceptionHandler.ShowExceptionError(ex.Message);
            }
        }

        public async void DoDeleteStatue()
        {
            try
            {
                LoadingIcon = true;
                var msg = await handlerStatue.DeleteStatue();
                var message = new MessageDialog(msg);
                await message.ShowAsync();
            }
            catch (Exception ex)
            {
                ExceptionHandler.ShowExceptionError(ex.Message);
            }
            finally
            {
                LoadingIcon = false;
            }
            GetStatueAsync();
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
