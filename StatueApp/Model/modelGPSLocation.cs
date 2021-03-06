﻿using StatueApp.Interface;

namespace StatueApp.Model
{
    public class modelGPSLocation : IWebUri, IGetByStatueId
    {
        public modelGPSLocation()
        {
            ResourceUri = "GPSLocations";
            VerboseName = "GPS Location";
            CanGetByStatueId = true;
        }

        public modelGPSLocation(string coordinates, int fkStatue) : this()
            // Konstrukerer objektet med parameterne og indholdet af standard contrutoren
        {
            Coordinates = coordinates;
            FK_Statue = fkStatue;
        }

        public modelGPSLocation(int id, string coordinates, int fkStatue) : this()
            // Konstrukerer objektet med parameterne og indholdet af standard contrutoren
        {
            Id = id;
            Coordinates = coordinates;
            FK_Statue = fkStatue;
        }

        public int Id { get; set; }
        public string Coordinates { get; set; }
        public int FK_Statue { get; set; }
        public bool CanGetByStatueId { get; }
        public string ResourceUri { get; }
        public string VerboseName { get; }
    }
}