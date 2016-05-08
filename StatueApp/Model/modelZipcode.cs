using StatueApp.Interface;

namespace StatueApp.Model
{
    // i WebService hedder class'en "City"
    public class modelZipcode : IWebUri
    {
        public modelZipcode()
        {
            ResourceUri = "Zipcodes";
            VerboseName = "Zipcode";
        }

        public modelZipcode(string zipcode) : this()
            // Constructs Object with parameters AND the content of the Default Constructor
        {
            Zipcode = zipcode;
        }

        public modelZipcode(string zipcode, string city1) : this()
            // Constructs Object with parameters AND the content of the Default Constructor
        {
            Zipcode = zipcode;
            City1 = city1;
        }

        public string Zipcode { get; set; }
        public string City1 { get; set; }
        public string ResourceUri { get; }
        public string VerboseName { get; }
    }
}