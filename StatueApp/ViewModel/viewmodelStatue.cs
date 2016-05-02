using StatueApp.Common;

namespace StatueApp.ViewModel
{
    class viewmodelStatue
    {

        StatueSingleton Singleton;
        public viewmodelStatue()
        {
            Singleton = StatueSingleton.Instance;
        }
    }
}
