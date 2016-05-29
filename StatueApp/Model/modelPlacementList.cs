using StatueApp.Interface;

namespace StatueApp.Model
{
    public class modelPlacementList : IWebUri, IGetByStatueId
    {
        public modelPlacementList()
        {
            ResourceUri = "PlacementLists";
            VerboseName = "List of Placements";
            CanGetByStatueId = true;
        }

        public modelPlacementList(int fkStatue, int fkPlacement) : this()
            // Konstrukerer objektet med parameterne og indholdet af standard contrutoren
        {
            FK_Statue = fkStatue;
            FK_Placement = fkPlacement;
        }

        public modelPlacementList(int id, int fkStatue, int fkPlacement) : this()
            // Konstrukerer objektet med parameterne og indholdet af standard contrutoren
        {
            Id = id;
            FK_Statue = fkStatue;
            FK_Placement = fkPlacement;
        }

        public int Id { get; set; }
        public int FK_Statue { get; set; }
        public int FK_Placement { get; set; }
        public bool CanGetByStatueId { get; }
        public string ResourceUri { get; }
        public string VerboseName { get; }
    }
}