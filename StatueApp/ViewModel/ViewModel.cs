using System;
using System.Collections.Generic;
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
    class ViewModel: INotifyPropertyChanged
    {
        public StatueSingleton StatueSingleton { get; }
        public PlacmentSingleton PlacementSingleton { get; }

        public ViewModel()
        {
            StatueSingleton=StatueSingleton.Instance;
            GetStatueTypeAsync();

            PlacementSingleton = PlacmentSingleton.Instance;
            GetStatuePlacementAsync();
        }
        /// <summary>
        /// Henter StatueTyper
        /// </summary>
        public async void GetStatueTypeAsync()
        {
            var listOfStatueType = await facadeStatue.GetListAsync(new modelStatueType());
            foreach (var statueType in listOfStatueType)
            {
                StatueSingleton.Add(statueType);
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
                PlacementSingleton.Add(statuePlacement);
            }
        }

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
