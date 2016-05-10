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

        public modelZipcode(string zipcodeValue) : this()
            // Constructs Object with parameters AND the content of the Default Constructor
        {
            ZipcodeValue = zipcodeValue;
        }

        public modelZipcode(string zipcodeValue, string cityName) : this()
            // Constructs Object with parameters AND the content of the Default Constructor
        {
            ZipcodeValue = zipcodeValue;
            CityName = cityName;
        }

        public string ZipcodeValue { get; set; }
        public string CityName { get; set; }
        public string ResourceUri { get; }
        public string VerboseName { get; }
    }
}