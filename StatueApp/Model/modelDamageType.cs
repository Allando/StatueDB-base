using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatueApp.Model
{
    public class modelDamageType
    {
        public int Id { get; set; }
        public string Type { get; set; }

        public modelDamageType(string type)
        {
            Type = type;
        }
    }
}
