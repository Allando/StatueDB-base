public class Singleton // Class name neeeds to be changed
{
    /// <summary>
    /// This is a sample Singleton Class. It shows the Code for a simple Singleton pattern
    /// Some changes are needed for this to be usable in C# Code
    /// </summary>

    private static Singleton _instance; // Should match class name

    private Singleton() { } // Constructor only accesible from inside the class itself

    /// <summary>
    /// Public Method that return a singleton refence
    /// </summary>
    public static Singleton Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new Singleton();
            }
            return _instance;
        }
    }
}

