using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using StatueApp.Annotations;
using StatueApp.Common;
using StatueApp.Facade;
using StatueApp.Model;

namespace StatueApp.ViewModel
{
    public class ViewModelAddDamage : INotifyPropertyChanged
    {
        #region Properties
        public static DamageSingleton NewDamage { get; set; }
        public static ObservableCollection<modelDamageType> DamageTypes;

        private bool _loadingIcon;
        public bool LoadingIcon
        {
            get { return _loadingIcon; }
            set { _loadingIcon = value; OnPropertyChanged(); }
        }
        #endregion

        #region Contructor
        //Constructor
        public ViewModelAddDamage()
        {
            NewDamage = DamageSingleton.Instance;

            DamageTypes = new ObservableCollection<modelDamageType>();
            GetDamageTypesAsync();
        }

        #endregion

        #region Metoder
        /// <summary>
        /// Henter alle Damage typer ind fra databasen og tilføjer dem til en ObservableCollection
        /// </summary>
        public async void GetDamageTypesAsync()
        {
            var listOfDamageTypes = await facadeStatue.GetListAsync(new modelDamageType());
            foreach (var item in listOfDamageTypes)
            {
                DamageTypes.Add(item);
            }
        } 
        #endregion

        #region PropertyChanged Support
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        } 
        #endregion
    }
}
