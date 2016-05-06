using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatueApp.Model
{
    public class StatueSingleton
    {
        /// <summary>
        /// This is a sample Singleton Class. It shows the Code for a simple Singleton pattern
        /// Some changes are needed for this to be usable in C# Code
        /// </summary>

        #region Collections
        public ObservableCollection<modelStatueType> StatueTypes { get; }

        #endregion


        private static StatueSingleton _instance; // Should match class name

        private StatueSingleton()
        {
            StatueTypes = new ObservableCollection<modelStatueType>();
        }

        // Constructor only accesible from inside the class itself

        /// <summary>
        /// Public Method that return a singleton refence
        /// </summary>
        public static StatueSingleton Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new StatueSingleton();
                }
                return _instance;
            }
        }

        public void Add(modelStatueType newStatue)
        {
            StatueTypes.Add(newStatue);
        }
    }
}
