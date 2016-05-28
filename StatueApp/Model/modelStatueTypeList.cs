using StatueApp.Interface;

namespace StatueApp.Model
{
    public class modelStatueTypeList : IWebUri, IGetByStatueId, IHasFkStatuecs
    {
        public modelStatueTypeList()
        {
            ResourceUri = "StatueTypeLists";
            VerboseName = "List of Statue Types";
            CanGetByStatueId = true;
        }

        public modelStatueTypeList(int fkStatue, int fkStatueType) : this()
            // Konstrukerer objektet med parameterne og indholdet af standard contrutoren
        {
            FK_Statue = fkStatue;
            FK_StatueType = fkStatueType;
        }

        public modelStatueTypeList(int id, int fkStatue, int fkStatueType) : this()
            // Konstrukerer objektet med parameterne og indholdet af standard contrutoren
        {
            Id = id;
            FK_Statue = fkStatue;
            FK_StatueType = fkStatueType;
        }

        public int Id { get; set; }
        public int FK_Statue { get; set; }
        public int FK_StatueType { get; set; }
        public bool CanGetByStatueId { get; }
        public string ResourceUri { get; }
        public string VerboseName { get; }
    }
}