using System;
using StatueApp.Interface;

namespace StatueApp.Model
{
    public class modelStatue : IWebUri
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Zipcode { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public string ResourceUri { get; }
        public string VerboseName { get; }

        public modelStatue()
        {
            ResourceUri = "Statue";
            VerboseName = "Statue";
        }

        public modelStatue(string name, string address, string zipcode, DateTime created, DateTime updated) : this()
        // Constructs Object with parameters AND the content of the Default Constructor
        {
            Name = name;
            Address = address;
            Zipcode = zipcode;
            Created = created;
            Updated = updated;
        }

        public modelStatue(int id, string name, string address, string zipcode, DateTime created, DateTime updated) :this()
        // Constructs Object with parameters AND the content of the Default Constructor
        {
            Id = id;
            Name = name;
            Address = address;
            Zipcode = zipcode;
            Created = created;
            Updated = updated;
        }
    }
}
