using StatueApp.Interface;

namespace StatueApp.Model
{
    public class modelMaterial : IWebUri
    {
        public modelMaterial()
        {
            ResourceUri = "Materials";
            VerboseName = "Material";
        }

        public modelMaterial(string materialName, string types)
            // Constructs Object with parameters AND the content of the Default Constructor
        {
            MaterialName = materialName;
            Types = types;
        }

        public modelMaterial(int id, string materialName, string types)
            // Constructs Object with parameters AND the content of the Default Constructor
        {
            Id = id;
            MaterialName = materialName;
            Types = types;
        }

        public int Id { get; set; }
        public string MaterialName { get; set; }
        public string Types { get; set; }
        public string ResourceUri { get; }
        public string VerboseName { get; }

        public override string ToString()
        {
            return $"{MaterialName}";
        }
    }
}