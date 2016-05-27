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
            // Konstrukerer objektet med parameterne og indholdet af standard contrutoren
        {
            PlacementName = placementName;
        }

        public modelPlacement(int id, string placementName) : this()
            // Konstrukerer objektet med parameterne og indholdet af standard contrutoren
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