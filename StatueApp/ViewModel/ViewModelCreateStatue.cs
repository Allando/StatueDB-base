﻿using System;
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
    public class ViewModelCreateStatue : INotifyPropertyChanged
    {
        #region Properties
        public static StatueSingleton NewStatue { get; set; }
        public static modelStatue SelectedStatueFromList { get; set; }

        public RelayCommand CreateStatueCommand { get; set; }
        public RelayCommand ViewStatueCommand { get; set; }

        public static ObservableCollection<modelStatueType> StatueType { get; set; }
        public static ObservableCollection<modelPlacement> StatuePlacement { get; set; }
        public static ObservableCollection<modelCulturalValue> CulturalValue { get; set; }
        public static ObservableCollection<modelImage> StatueImage { get; set; }
        public static ObservableCollection<modelMaterial> StatueMaterial { get; set; }

        public static ObservableCollection<modelMaterial> StatueMaterialStone { get; set; }
        public static ObservableCollection<modelMaterial> StatueMaterialMetal { get; set; }
        public static ObservableCollection<modelMaterial> StatueMaterialOther { get; set; }
        public static ObservableCollection<modelStatue> Statues { get; set; }
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

            Statues = new ObservableCollection<modelStatue>();
            GetStatueAsync();

            CreateStatueCommand = new RelayCommand(DoCreateStatue);
            ViewStatueCommand = new RelayCommand(ViewStatue);
        }
        #endregion

        #region Methods
        #region Liste Generatorer
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
            //Bliver returneret til GetStatueMaterialAsync metoden
            return materialList;
        }

        /// <summary>
        /// Henter og laver liste over Statue Typer
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
        /// Henter og laver liste over Statue Placeringer
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
        /// Henter og laver liste over Kulturelle Værdier
        /// </summary>
        public async void GetCulturalValueAsync()
        {
            var listOfCulturalValue = await facadeStatue.GetListAsync(new modelCulturalValue());
            foreach (var culturalValue in listOfCulturalValue)
            {
                CulturalValue.Add(culturalValue);
            }
        }

        /// <summary>
        /// Henter og laver liste over statue Billeder
        /// </summary>
        public async void GetStatueImageAsync()
        {
            var listOfStatueImage = await facadeStatue.GetListAsync(new modelImage());
            foreach (var statueImage in listOfStatueImage)
            {
                StatueImage.Add(statueImage);
            }
        }

        /// <summary>
        /// Henter og laver liste over statue Materialler
        /// </summary>
        public async void GetStatueMaterialAsync()
        {
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

        /// <summary>
        /// Henter og laver liste over statuer
        /// </summary>
        public async void GetStatueAsync()
        {
            var listOfStatues = await facadeStatue.GetListAsync(new modelStatue());
            Statues.Clear();
            foreach (var statue in listOfStatues)
            {
                Statues.Add(statue);
            }
        }
        #endregion

        #region RelayCommands
        /// <summary>
        /// Opretter statuen og returnere en besked fra webservicen
        /// </summary>
        public async void  DoCreateStatue()
        {
            var msg = await handlerStatue.CreateStatue();
            var message = new MessageDialog(msg);
            await message.ShowAsync();
        }

        /// <summary>
        /// Denne metode udfylder properties så man kan se en specifik statue på SeeStatue Viewet + navigere til viewet 
        /// </summary>
        public void ViewStatue()
        {
            NewStatue.SelectedStatue.Name = SelectedStatueFromList.Name;
            NewStatue.SelectedStatue.Address = SelectedStatueFromList.Address;

            //Navigaere til viewet SeeStatue
            NavigationHelper.navigate(typeof(SeeStatue));
        }
        #endregion
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
