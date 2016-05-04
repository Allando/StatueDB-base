using StatueApp.Interface;

namespace StatueApp.Model
{
    public class modelMaterial : IWebUri
    {
        public int Id { get; set; }
        public string Material1 { get; set; }
        public string Types { get; set; }
        public string ResourceUri { get; }
        public string VerboseName { get; }

        public modelMaterial()
        {
            ResourceUri = "Material";
            VerboseName = "Material";
        }

        public modelMaterial(int id, string material1, string types)
        // Constructs Object with parameters AND the content of the Default Constructor
        {
            Id = id;
            Material1 = material1;
            Types = types;
        }
    }
}
