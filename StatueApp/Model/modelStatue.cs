﻿using System;
using StatueApp.Interface;

namespace StatueApp.Model
{
    public class modelStatue : IWebUri
    {
        public modelStatue()
        {
            ResourceUri = "Statues";
            VerboseName = "Statue";
        }

        public modelStatue(string name, string address, string zipcode, DateTime created, DateTime updated) : this()
            // Konstrukerer objektet med parameterne og indholdet af standard contrutoren
        {
            Name = name;
            Address = address;
            Zipcode = zipcode;
            Created = created;
            Updated = updated;
        }

        public modelStatue(int id, string name, string address, string zipcode, DateTime created, DateTime updated)
            : this()
            // Konstrukerer objektet med parameterne og indholdet af standard contrutoren
        {
            Id = id;
            Name = name;
            Address = address;
            Zipcode = zipcode;
            Created = created;
            Updated = updated;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Zipcode { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public string ResourceUri { get; }
        public string VerboseName { get; }

        public override string ToString()
        {
            return $"Nr: {Id}, Statue: {Name}";
        }
    }
}