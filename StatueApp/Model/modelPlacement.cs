using StatueApp.Interface;

namespace StatueApp.Model
{
    public class modelPlacement : IWebUri
    {
        public int Id { get; set; }
        public string Placement1 { get; set; }
        public string ResourceUri { get; }
        public string VerboseName { get; }

        public modelPlacement()
        {
            ResourceUri = "Placement";
            VerboseName = "Placement";
        }

        public modelPlacement(int id, string placement1) : this()
        // Constructs Object with parameters AND the content of the Default Constructor
        {
            Id = id;
            Placement1 = placement1;
        }
    }
}
