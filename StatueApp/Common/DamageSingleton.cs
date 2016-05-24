using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using StatueApp.Annotations;
using StatueApp.Model;

namespace StatueApp.Common
{
    public class DamageSingleton : INotifyPropertyChanged, IDisposable
    {
        public int StatueId { get; set; }
        public modelDamage Damage { get; set; }
        public modelDamageType DamageType { get; set; }
        public ObservableCollection<modelImage> Images { get; set; }

        private static DamageSingleton _instance;

        private DamageSingleton()
        {
            StatueId = -1;
            Damage = new modelDamage();
            DamageType = new modelDamageType();
            Images = new ObservableCollection<modelImage>();
        }

        public static DamageSingleton Instance => _instance ?? (_instance = new DamageSingleton());

        #region PropertyChanged Support
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        #region Disposable Support
        /// <summary>
        /// Bruges til at nulstille Singleton'en
        /// </summary>
        public void Dispose()
        {
            _instance.Dispose();
        }
        #endregion
    }
}
