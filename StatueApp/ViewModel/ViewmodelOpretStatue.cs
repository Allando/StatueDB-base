using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StatueApp.Common;

namespace StatueApp.ViewModel
{
    class ViewmodelOpretStatue
    {
       public StatueSingleton Singleton { get; }

        public ViewmodelOpretStatue()
        {
            Singleton = StatueSingleton.Instance;
        }
    }
}
