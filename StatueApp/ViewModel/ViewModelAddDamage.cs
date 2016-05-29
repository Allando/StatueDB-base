using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Windows.UI.Popups;
using StatueApp.Annotations;
using StatueApp.Common;
using StatueApp.Facade;
using StatueApp.Handler;
using StatueApp.Model;

namespace StatueApp.ViewModel
{
    public class ViewModelAddDamage : INotifyPropertyChanged
    {
        #region Properties
        public static DamageSingleton NewDamage { get; set; }
        public static StatueSingleton SelectedStatue { get; set; }
        public modelDamageType SelectedDamageType
        {
            get { return _selectedDamageType; }
            set {_selectedDamageType = value; OnPropertyChanged(); }
        }
        public RelayCommand AddDamageCommand { get; set; }
        public static ObservableCollection<modelDamageType> DamageTypes { get; set; }
        public static ObservableCollection<DamageSingleton> Damages { get; set; }

        private bool _loadingIcon;
        private static modelDamageType _selectedDamageType;

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
            SelectedStatue = StatueSingleton.Instance;

            try
            {
                DamageTypes = new ObservableCollection<modelDamageType>();
                GetDamageTypesAsync();
            }
            catch (Exception ex)
            {
                ExceptionHandler.ShowExceptionError(ex.Message);
            }
            AddDamageCommand=new RelayCommand(DoAddDamage);
        }
        #endregion

        #region Metoder
        /// <summary>
        /// Beder Handler Damage om at køre metoden AddDamage med den tilhørende Selected Statues Id.
        /// </summary>
        public async void DoAddDamage()
        {
            NewDamage.Damage.FK_DamageType = SelectedDamageType.Id;
            NewDamage.Damage.FK_Statue = SelectedStatue.SelectedStatue.Id;
            try
            {
                var msg = await handlerDamage.AddDamage(SelectedStatue.SelectedStatue.Id);
                var message = new MessageDialog(msg);
                await message.ShowAsync();
            }
            catch (Exception ex)
            {
                ExceptionHandler.ShowExceptionError(ex.Message);
            }
        }
        /// <summary>
        /// Henter alle Damage typer ind fra databasen og tilføjer dem til en ObservableCollection
        /// </summary>
        public async void GetDamageTypesAsync()
        {
            DamageTypes.Clear();
            try
            {
                var listOfDamageTypes = await facadeStatue.GetListAsync(new modelDamageType());
                foreach (var item in listOfDamageTypes)
                {
                    DamageTypes.Add(item);
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.ShowExceptionError(ex.Message);
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
