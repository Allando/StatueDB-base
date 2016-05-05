using StatueApp.Interface;

namespace StatueApp.Model
{
    class modelStatueType : IWebUri
    {
        public int Id { get; set; }
        public string StatueType_ { get; set; }
        public string ResourceUri { get; }
        public string VerboseName { get; }

        public modelStatueType()
        {
            ResourceUri = "StatueType";
            VerboseName = "Type of Statue";
        }

        public modelStatueType(string statueType) : this()
        // Constructs Object with parameters AND the content of the Default Constructor
        {
            StatueType_ = statueType;
        }

        public modelStatueType(int id, string statueType) : this()
        // Constructs Object with parameters AND the content of the Default Constructor
        {
            Id = id;
            StatueType_ = statueType;
        }
    }
}
