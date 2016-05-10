using StatueApp.Interface;

namespace StatueApp.Model
{
    public class modelStatueType : IWebUri
    {
        public modelStatueType()
        {
            ResourceUri = "StatueTypes";
            VerboseName = "Type of Statue";
        }

        public modelStatueType(string statueTypeName) : this()
            // Constructs Object with parameters AND the content of the Default Constructor
        {
            StatueTypeName = statueTypeName;
        }

        public modelStatueType(int id, string statueTypeName) : this()
            // Constructs Object with parameters AND the content of the Default Constructor
        {
            Id = id;
            StatueTypeName = statueTypeName;
        }

        public int Id { get; set; }
        public string StatueTypeName { get; set; }
        public string ResourceUri { get; }
        public string VerboseName { get; }

        public override string ToString()
        {
            return $"{StatueTypeName}";
        }
    }
}