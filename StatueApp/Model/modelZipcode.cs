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
            // Konstrukerer objektet med parameterne og indholdet af standard contrutoren
        {
            ZipcodeValue = zipcodeValue;
        }

        public modelZipcode(string zipcodeValue, string cityName) : this()
            // Konstrukerer objektet med parameterne og indholdet af standard contrutoren
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