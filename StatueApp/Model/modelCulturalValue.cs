using StatueApp.Interface;

namespace StatueApp.Model
{
    public class modelCulturalValue : IWebUri
    {
        public int Id { get; set; }
        public string CulturalValue1 { get; set; }
        public string ResourceUri { get; }
        public string VerboseName { get; }

        public modelCulturalValue()
        {
            ResourceUri = "CulturalValue";
            VerboseName = "Cultural Value";
        }

        public modelCulturalValue(int id, string culturalValue1) : this()
        // Constructs Object with parameters AND the content of the Default Constructor
        {
            Id = id;
            CulturalValue1 = culturalValue1;
        }
    }
}
