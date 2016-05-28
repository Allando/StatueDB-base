using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatueApp.Exeption
{
    class ServerErrorExeption : Exception
    {
        public ServerErrorExeption() : base()
        {
            
        }

        public ServerErrorExeption(string message) : base(message)
        {
            
        }
    }
}
