using StatueApp.Interface;

namespace StatueApp.Model
{
    public class modelDescription:IWebUri
    {
        public int Id { get; set; }
        public int FK_Statue { get; set; }
        public string Description { get; set; }
        public string ResourceUri { get; }
        public string VerboseName { get; }

        public modelDescription()
        {
            ResourceUri = "Description";
            VerboseName = "Description";
        }
    }
}
