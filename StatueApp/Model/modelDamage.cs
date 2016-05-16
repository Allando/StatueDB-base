using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace StatueApp.Model
{
    public class modelDamage
    {
        public int Id { get; private set; }
        public string DamageDescription { get; set; }
        public int FK_Statue { get; set; }
        public int FK_DamageType { get; set; }
        public int FK_Placement { get; set; }
        public DateTime CreatedDate { get; set; }

        public modelDamage()
        {
            CreatedDate=DateTime.Today;
        }

        public modelDamage(string damageDescription, int fkStatue, int fkDamageType, int fkPlacement)
        {
            DamageDescription = damageDescription;
            FK_Statue = fkStatue;
            FK_DamageType = fkDamageType;
            FK_Placement = fkPlacement;
            CreatedDate = DateTime.Today;
        }

    }
}
