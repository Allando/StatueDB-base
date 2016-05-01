using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using StatueApp.Annotations;

internal class ObservabelCollectionSingleton : INotifyPropertyChanged
{
    /// <summary>
    /// This is a sample Observable Collection Singleton Class.
    /// Some changes are needed for this to be usable in C# Code
    /// </summary>

    // Properties
    public ObservableCollection<object> ObservableCollectionSingleton { get; set; }
    public static ObservabelCollectionSingleton Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new ObservabelCollectionSingleton();
            }
            return _instance;
        }
    }
    
    // Instancers
    private static ObservabelCollectionSingleton _instance;

    // Constructor
    private ObservabelCollectionSingleton()
    {
        ObservableCollectionSingleton = new ObservableCollection<object>();
    }

    // Methods
    public void Add(object newObject)
    {
        ObservableCollectionSingleton.Add(newObject);
    }

    public void Remove(object objectToBeRemoved)
    {
        ObservableCollectionSingleton.Remove(objectToBeRemoved);
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