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

        public modelPlacement(string placement1) : this()
            // Constructs Object with parameters AND the content of the Default Constructor
        {
            Placement1 = placement1;
        }

        public modelPlacement(int id, string placement1) : this()
            // Constructs Object with parameters AND the content of the Default Constructor
        {
            Id = id;
            Placement1 = placement1;
        }

        public int Id { get; set; }
        public string Placement1 { get; set; }
        public string ResourceUri { get; }
        public string VerboseName { get; }

        public override string ToString()
        {
            return $"{Placement1}";
        }
    }
}