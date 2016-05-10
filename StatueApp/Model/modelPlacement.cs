using StatueApp.Interface;

namespace StatueApp.Model
{
    public class modelPlacement : IWebUri
    {
        public modelPlacement()
        {
            ResourceUri = "Placements";
            VerboseName = "Placement";
        }

        public modelPlacement(string placementName) : this()
            // Constructs Object with parameters AND the content of the Default Constructor
        {
            PlacementName = placementName;
        }

        public modelPlacement(int id, string placementName) : this()
            // Constructs Object with parameters AND the content of the Default Constructor
        {
            Id = id;
            PlacementName = placementName;
        }

        public int Id { get; set; }
        public string PlacementName { get; set; }
        public string ResourceUri { get; }
        public string VerboseName { get; }

        public override string ToString()
        {
            return $"{PlacementName}";
        }
    }
}