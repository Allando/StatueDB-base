using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using StatueApp.Annotations;
using StatueApp.Common;
using StatueApp.Facade;
using StatueApp.Model;

namespace StatueApp.ViewModel
{
    public class ViewModelAddDamage : INotifyPropertyChanged
    {
        public static DamageSingleton NewDamage { get; set; }
        public static ObservableCollection<modelDamageType> DamageTypes;

        public ViewModelAddDamage()
        {
            NewDamage = DamageSingleton.Instance;

            DamageTypes = new ObservableCollection<modelDamageType>();
            GetDamageTypesAsync();
        }

        public async void GetDamageTypesAsync()
        {
            var listOfDamageTypes = await facadeStatue.GetListAsync(new modelDamageType());
            foreach (var item in listOfDamageTypes)
            {
                DamageTypes.Add(item);
            }
        }

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
