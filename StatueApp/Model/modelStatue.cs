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

    }
}
