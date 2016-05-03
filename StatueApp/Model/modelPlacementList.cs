using StatueApp.Interface;

namespace StatueApp.Model
{
    public class modelPlacementList:IWebUri
    {
        public int Id { get; set; }
        public int FK_Statue { get; set; }
        public int FK_Placement { get; set; }
        public string ResourceUri { get; }
        public string VerboseName { get; }

        public modelPlacementList()
        {
            ResourceUri = "PlacementList";
            VerboseName = "List of Placements";
        }
    }
}
