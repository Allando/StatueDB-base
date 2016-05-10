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
        public StatueTypeSingleton StatueTypeSingleton { get; }
        public PlacmentSingleton PlacementSingleton { get; } 
        #endregion

        #region Constructors
        public ViewModelCreateStatue()
        {
            //Henter singleton ned så den kan bruges i meotderne
            StatueTypeSingleton = StatueTypeSingleton.Instance;
            //Skyder metoden så den bruges
            GetStatueTypeAsync();

            //Henter singleton ned så den kan bruges i meotderne
            PlacementSingleton = PlacmentSingleton.Instance;
            //Skyder metoden så den bruges
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
                StatueTypeSingleton.StatueTypes.Add(statueType);
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
                PlacementSingleton.Placements.Add(statuePlacement);
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
