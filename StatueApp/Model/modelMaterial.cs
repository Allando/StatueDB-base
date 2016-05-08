﻿using StatueApp.Interface;

namespace StatueApp.Model
{
    public class modelMaterial : IWebUri
    {
        public modelMaterial()
        {
            ResourceUri = "Materials";
            VerboseName = "Material";
        }

        public modelMaterial(string material1, string types)
            // Constructs Object with parameters AND the content of the Default Constructor
        {
            Material1 = material1;
            Types = types;
        }

        public modelMaterial(int id, string material1, string types)
            // Constructs Object with parameters AND the content of the Default Constructor
        {
            Id = id;
            Material1 = material1;
            Types = types;
        }

        public int Id { get; set; }
        public string Material1 { get; set; }
        public string Types { get; set; }
        public string ResourceUri { get; }
        public string VerboseName { get; }
    }
}