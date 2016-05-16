using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatueApp.Model
{
    public class modelDamageImageList
    {
        public int Id { get; private set; }
        public int FK_Damage { get; set; }
        public int FK_Image { get; set; }

        public modelDamageImageList(int fkDamage, int fkImage)
        {
            FK_Damage = fkDamage;
            FK_Image = fkImage;
        }
    }
}
