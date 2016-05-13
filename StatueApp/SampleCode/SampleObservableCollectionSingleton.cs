using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using StatueApp.Annotations;

internal class SampleObservabelCollectionSingleton : INotifyPropertyChanged
{
    /// <summary>
    /// This is a sample Observable Collection Singleton Class.
    /// Some changes are needed for this to be usable in C# Code
    /// </summary>

    // Properties
    public ObservableCollection<object> ObservableCollectionSingleton { get; set; }
    public static SampleObservabelCollectionSingleton Instance
    {
        get { return _instance ?? (_instance = new SampleObservabelCollectionSingleton()); }
    }
    
    // Instancers
    private static SampleObservabelCollectionSingleton _instance;

    // Constructor
    private SampleObservabelCollectionSingleton()
    {
        ObservableCollectionSingleton = new ObservableCollection<object>();
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