using StatueApp.Interface;

namespace StatueApp.Model
{
    class modelStatueTypeList : IWebUri, IGetByStatueId
    {
        public int Id { get; set; }
        public int FK_Statue { get; set; }
        public int FK_StatueType { get; set; }
        public string ResourceUri { get; }
        public string VerboseName { get; }
        public bool CanGetByStatueId { get; }

        public modelStatueTypeList()
        {
            ResourceUri = "StatueTypeList";
            VerboseName = "List of Statue Types";
            CanGetByStatueId = true;
        }

        public modelStatueTypeList(int fkStatue, int fkStatueType) : this()
        // Constructs Object with parameters AND the content of the Default Constructor
        {
            FK_Statue = fkStatue;
            FK_StatueType = fkStatueType;
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
