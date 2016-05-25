using System;
using StatueApp.Interface;

namespace StatueApp.Model
{
    public class modelDamage : IWebUri
    {

        public string ResourceUri { get; } 
        public string VerboseName { get; }

        // Properties
        public int Id { get; set; }
        public string DamageDescription { get; set; }
        public int FK_Statue { get; set; }
        public int FK_DamageType { get; set; }
        public string Placement { get; set; }
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Default Constructor
        /// </summary>
        public modelDamage()
        {
            ResourceUri = "Damages";
            VerboseName = "Damage";
            CreatedDate = DateTime.Now;
        }

        /// <summary>
        /// Custom Constructor
        /// </summary>
        /// <param name="damageDescription">Kort beskrivelse af skaden</param>
        /// <param name="fkStatue">Id på statuen</param>
        /// <param name="fkDamageType">Id på skadestypen</param>
        /// <param name="placement">Skadens placering</param>
        public modelDamage(string damageDescription, int fkStatue, int fkDamageType, string placement) : this()
        {
            DamageDescription = damageDescription;
            FK_Statue = fkStatue;
            FK_DamageType = fkDamageType;
            Placement = placement;
        }

    }
}
