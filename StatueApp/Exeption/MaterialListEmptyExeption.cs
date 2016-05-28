using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatueApp.Exeption
{
    class MaterialListEmptyExeption : Exception
    {
        public MaterialListEmptyExeption() : base()
        {
            
        }

        public MaterialListEmptyExeption(string message) : base(message)
        {
            
        }
    }
}
