using StatueApp.Interface;

namespace StatueApp.Model
{
    // i WebService hedder class'en "City"
    class modelZipcode : IWebUri
    {
        public string Zipcode { get; set; }
        public string City1 { get; set; }
        public string ResourceUri { get; }
        public string VerboseName { get; }

        public modelZipcode()
        {
            ResourceUri = "City";
            VerboseName = "Zipcode";
        }

        public modelZipcode(string zipcode, string city1) : this()
        // Constructs Object with parameters AND the content of the Default Constructor
        {
            Zipcode = zipcode;
            City1 = city1;
        }
    }
}
