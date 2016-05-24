using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StatueApp.Interface;

namespace StatueApp.Model
{
    public class modelDamageImageList : IWebUri
    {
        public string ResourceUri { get; }
        public string VerboseName { get; }

        public int Id { get; set; }
        public int FK_Damage { get; set; }
        public int FK_Image { get; set; }

        public modelDamageImageList()
        {
            ResourceUri = "DamageImageLists";
            VerboseName = "Damage Image";
        }

        public modelDamageImageList(int fkDamage, int fkImage) : this()
        {
            FK_Damage = fkDamage;
            FK_Image = fkImage;
        }

        public modelDamageImageList(int id, int fkDamage, int fkImage) : this()
        {
            Id = id;
            FK_Damage = fkDamage;
            FK_Image = fkImage;
        }

    }
}
