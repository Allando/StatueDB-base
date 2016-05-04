using StatueApp.Interface;

namespace StatueApp.Model
{
    public class modelGPSLocation : IWebUri
    {
        public int Id { get; set; }
        public string Coordinates { get; set; }
        public int FK_Statue { get; set; }
        public string ResourceUri { get; }
        public string VerboseName { get; }

        public modelGPSLocation()
        {
            ResourceUri = "GPSLocation";
            VerboseName = "GPS Location";
        }

        public modelGPSLocation(int id, string coordinates, int fkStatue):this()
        // Constructs Object with parameters AND the content of the Default Constructor
        {
            Id = id;
            Coordinates = coordinates;
            FK_Statue = fkStatue;
        }
    }
}
