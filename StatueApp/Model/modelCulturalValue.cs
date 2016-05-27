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

        public modelCulturalValue(string culturalValueChar) : this()
            //Konstrukerer objektet med parameterne og indholdet af standard contrutoren
        {
            CulturalValueChar = culturalValueChar;
        }

        public modelCulturalValue(int id, string culturalValueName) : this()
            // Konstrukerer objektet med parameterne og indholdet af standard contrutoren
        {
            Id = id;
            CulturalValueChar = culturalValueName;
        }

        public int Id { get; set; }
        public string CulturalValueChar { get; set; }
        public string ResourceUri { get; }
        public string VerboseName { get; }

        public override string ToString()
        {
            return $"{CulturalValueChar}";
        }
    }
}