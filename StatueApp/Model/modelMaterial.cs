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

        public modelMaterial(string materialName, string materialType)
            // Konstrukerer objektet med parameterne og indholdet af standard contrutoren
        {
            MaterialName = materialName;
            MaterialType = materialType;
        }

        public modelMaterial(int id, string materialName, string materialType)
            // Konstrukerer objektet med parameterne og indholdet af standard contrutoren
        {
            Id = id;
            MaterialName = materialName;
            MaterialType = materialType;
        }

        public int Id { get; set; }
        public string MaterialName { get; set; }
        public string MaterialType { get; set; }
        public string ResourceUri { get; }
        public string VerboseName { get; }

        public override string ToString()
        {
            return $"{MaterialName}";
        }
    }
}