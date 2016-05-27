using StatueApp.Interface;

namespace StatueApp.Model
{
    public class modelDescription : IWebUri, IGetByStatueId
    {
        public modelDescription()
        {
            ResourceUri = "Descriptions";
            VerboseName = "Description";
            CanGetByStatueId = true;
        }

        public modelDescription(int fkStatue, string description) : this()
            // Konstrukerer objektet med parameterne og indholdet af standard contrutoren
        {
            FK_Statue = fkStatue;
            Description = description;
        }

        public modelDescription(int id, int fkStatue, string description) : this()
            // Konstrukerer objektet med parameterne og indholdet af standard contrutoren
        {
            Id = id;
            FK_Statue = fkStatue;
            Description = description;
        }

        public int Id { get; set; }
        public int FK_Statue { get; set; }
        public string Description { get; set; }
        public bool CanGetByStatueId { get; }
        public string ResourceUri { get; }
        public string VerboseName { get; }
    }
}