using StatueApp.Interface;

namespace StatueApp.Model
{
    public class modelCulturalValueList : IWebUri, IGetByStatueId
    {
        public int Id { get; set; }
        public int FK_Statue { get; set; }
        public int FK_CulturalValue { get; set; }
        public string ResourceUri { get; }
        public string VerboseName { get; }
        public bool CanGetByStatueId { get; }

        public modelCulturalValueList()
        {
            ResourceUri = "CulturalValueList";
            VerboseName = "List of Cultural Values";
            CanGetByStatueId = true;
        }

        public modelCulturalValueList(int fkStatue, int fkCulturalValue) : this()
        // Constructs Object with parameters AND the content of the Default Constructor
        {
            FK_Statue = fkStatue;
            FK_CulturalValue = fkCulturalValue;
        }

        public modelCulturalValueList(int id, int fkStatue, int fkCulturalValue) : this() 
        // Constructs Object with parameters AND the content of the Default Constructor
        {
            Id = id;
            FK_Statue = fkStatue;
            FK_CulturalValue = fkCulturalValue;
        }
    }
}
