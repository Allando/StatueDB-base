using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using StatueApp.Annotations;
using StatueApp.Model;

namespace StatueApp.Common
{
    public class DamageSingleton : INotifyPropertyChanged
    {
        #region Properties
        public int StatueId { get; set; }
        public modelDamage Damage { get; set; }
        public modelDamageType DamageType { get; set; }
        public ObservableCollection<modelImage> Images { get; set; }

        private static DamageSingleton _instance;

        #endregion

        #region Contructor
        private DamageSingleton()
        {
            StatueId = -1;
            Damage = new modelDamage();
            DamageType = new modelDamageType();
            Images = new ObservableCollection<modelImage>();
        }
        #endregion

        #region Singleton
        /// <summary>
        /// Denne metode gør så der kun er en damage singleTon, ved at retunere instance i stedet for at lave en ny instance
        /// </summary>
        public static DamageSingleton Instance => _instance ?? (_instance = new DamageSingleton()); ///
        #endregion

        #region PropertyChanged Support
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        /// <summary>
        /// Bruges til at nulstille Singleton'en
        /// </summary>
        public void Dispose()
        {
            _instance.Damage = new modelDamage();
            _instance.DamageType = new modelDamageType();
            _instance.Images.Clear();
            _instance.StatueId = -1;
        }
    }
}
