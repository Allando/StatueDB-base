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
            // Constructs Object with parameters AND the content of the Default Constructor
        {
            FK_Statue = fkStatue;
            Description = description;
        }

        public modelDescription(int id, int fkStatue, string description) : this()
            // Constructs Object with parameters AND the content of the Default Constructor
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