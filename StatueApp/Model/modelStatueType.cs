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

        public int Id { get; set; }
        public string StatueType_ { get; set; }
        public string ResourceUri { get; }
        public string VerboseName { get; }

        public override string ToString()
        {
            return $"{StatueType_}";
        }
    }
}