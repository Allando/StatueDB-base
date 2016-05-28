using StatueApp.Interface;

namespace StatueApp.Model
{
    public class modelCulturalValueList : IWebUri, IGetByStatueId, IHasFkStatuecs
    {
        public modelCulturalValueList()
        {
            ResourceUri = "CulturalValueLists";
            VerboseName = "List of Cultural Values";
            CanGetByStatueId = true;
        }

        public modelCulturalValueList(int fkStatue, int fkCulturalValue) : this()
            // Konstrukerer objektet med parameterne og indholdet af standard contrutoren
        {
            FK_Statue = fkStatue;
            FK_CulturalValue = fkCulturalValue;
        }

        public modelCulturalValueList(int id, int fkStatue, int fkCulturalValue) : this()
            // Konstrukerer objektet med parameterne og indholdet af standard contrutoren
        {
            Id = id;
            FK_Statue = fkStatue;
            FK_CulturalValue = fkCulturalValue;
        }

        public int Id { get; set; }
        public int FK_Statue { get; set; }
        public int FK_CulturalValue { get; set; }
        public bool CanGetByStatueId { get; }
        public string ResourceUri { get; }
        public string VerboseName { get; }
    }
}