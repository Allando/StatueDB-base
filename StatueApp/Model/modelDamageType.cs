using StatueApp.Interface;

namespace StatueApp.Model
{
    public class modelDamageType : IWebUri
    {
        public string ResourceUri { get; }
        public string VerboseName { get; }

        public int Id { get; set; }
        public string Type { get; set; }

        public modelDamageType()
        {
            ResourceUri = "DamageTypes";
            VerboseName = "Damage Type";
        }

        public modelDamageType(string type) : this()
        {
            //Konstrukerer objektet med parameterne og indholdet af standard contrutoren
            Type = type;
        }

        public modelDamageType(int id, string type) : this()
        {
            //Konstrukerer objektet med parameterne og indholdet af standard contrutoren
            Id = id;
            Type = type;
        }

    }
}
