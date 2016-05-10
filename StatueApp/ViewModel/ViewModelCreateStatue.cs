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
    class ViewModelCreateStatue: INotifyPropertyChanged
    {
        #region Properties
        public static ObservableCollection<modelStatueType> StatueType { get; set; }
        public static ObservableCollection<modelPlacement> StatuePlacement  { get; set; } 
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
        } 
        #endregion

        #region Methods
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
