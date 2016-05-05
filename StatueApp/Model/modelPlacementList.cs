using StatueApp.Interface;

namespace StatueApp.Model
{
    public class modelPlacementList : IWebUri, IGetByStatueId
    {
        public int Id { get; set; }
        public int FK_Statue { get; set; }
        public int FK_Placement { get; set; }
        public string ResourceUri { get; }
        public string VerboseName { get; }
        public bool CanGetByStatueId { get; }

        public modelPlacementList()
        {
            ResourceUri = "PlacementList";
            VerboseName = "List of Placements";
            CanGetByStatueId = true;
        }

        public modelPlacementList(int fkStatue, int fkPlacement) : this()
        // Constructs Object with parameters AND the content of the Default Constructor
        {
            FK_Statue = fkStatue;
            FK_Placement = fkPlacement;
        }

        public modelPlacementList(int id, int fkStatue, int fkPlacement) : this()
        // Constructs Object with parameters AND the content of the Default Constructor
        {
            Id = id;
            FK_Statue = fkStatue;
            FK_Placement = fkPlacement;
        }

    }
}
