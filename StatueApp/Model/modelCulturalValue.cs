using StatueApp.Interface;

namespace StatueApp.Model
{
    public class modelCulturalValue : IWebUri
    {
        public modelCulturalValue()
        {
            ResourceUri = "CulturalValues";
            VerboseName = "Cultural Value";
        }

        public modelCulturalValue(string culturalValueName) : this()
            // Constructs Object with parameters AND the content of the Default Constructor
        {
            CulturalValueName = culturalValueName;
        }

        public modelCulturalValue(int id, string culturalValueName) : this()
            // Constructs Object with parameters AND the content of the Default Constructor
        {
            Id = id;
            CulturalValueName = culturalValueName;
        }

        public int Id { get; set; }
        public string CulturalValueName { get; set; }
        public string ResourceUri { get; }
        public string VerboseName { get; }

        public override string ToString()
        {
            return $"{CulturalValueName}";
        }
    }
}