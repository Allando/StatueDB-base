using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatueApp.Exeption
{
    class CreateStatueDeleteFailExeption : Exception
    {
        public CreateStatueDeleteFailExeption() : base()
        {
            
        }

        public CreateStatueDeleteFailExeption(string message) : base(message)
        {
            
        }
    }
}
