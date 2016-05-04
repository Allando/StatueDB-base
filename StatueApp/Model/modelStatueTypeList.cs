using StatueApp.Interface;

namespace StatueApp.Model
{
    class modelStatueTypeList : IWebUri
    {
        public int Id { get; set; }
        public int FK_Statue { get; set; }
        public int FK_StatueType { get; set; }
        public string ResourceUri { get; }
        public string VerboseName { get; }

        public modelStatueTypeList()
        {
            ResourceUri = "";
            VerboseName = "";
        }

        public modelStatueTypeList(int id, int fkStatue, int fkStatueType) : this()
        // Constructs Object with parameters AND the content of the Default Constructor
        {
            Id = id;
            FK_Statue = fkStatue;
            FK_StatueType = fkStatueType;
        }
    }
}
