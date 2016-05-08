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
    public class StatueSingleton : INotifyPropertyChanged
    {
        /// <summary>
        /// This is a sample Singleton Class. It shows the Code for a simple Singleton pattern
        /// Some changes are needed for this to be usable in C# Code
        /// </summary>

        public ObservableCollection<modelStatueType> StatueTypes { get; }

        public static StatueSingleton Instance => _instance ?? (_instance = new StatueSingleton());

        private static StatueSingleton _instance; // Should match class name

        private StatueSingleton()
        {
            StatueTypes = new ObservableCollection<modelStatueType>();
        }

        // Constructor only accesible from inside the class itself

        /// <summary>
        /// Public Method that return a singleton refence
        /// </summary>

        public void Add(modelStatueType newStatue)
        {
            StatueTypes.Add(newStatue);
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
