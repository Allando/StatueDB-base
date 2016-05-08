using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using StatueApp.Annotations;

namespace StatueApp.Model
{
    public class PlacmentSingleton : INotifyPropertyChanged
    {
        /// <summary>
        /// This is a sample Singleton Class. It shows the Code for a simple Singleton pattern
        /// Some changes are needed for this to be usable in C# Code
        /// </summary>
        #region Collections
        public ObservableCollection<modelPlacement> Placements { get; }

        public static PlacmentSingleton Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new PlacmentSingleton();
                }
                return _instance;
            }
        }

        #endregion
        private static PlacmentSingleton _instance; // Should match class name

        private PlacmentSingleton()
        {
            Placements = new ObservableCollection<modelPlacement>();
        }
        // Constructor only accesible from inside the class itself

        /// <summary>
        /// Public Method that return a singleton refence
        /// </summary>
       

        public void Add(modelPlacement newPlacement)
        {
            Placements.Add(newPlacement);
        }

        #region PropetyChangedSupport
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        } 
        #endregion
    }
}
