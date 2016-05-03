using StatueApp.Interface;

namespace StatueApp.Model
{
    public class modelCulturalValueList : IWebUri
    {
        public int Id { get; set; }
        public int FK_Statue { get; set; }
        public int FK_CulturalValue { get; set; }
        public string ResourceUri { get; }
        public string VerboseName { get; }

        public modelCulturalValueList()
        {
            ResourceUri = "CulturalValueList";
            VerboseName = "List of Cultural Values";
        }
    }
}
