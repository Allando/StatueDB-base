using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StatueApp.Model;

namespace StatueApp.Common
{
    public class StatueSingleton
    {

        public modelCulturalValue CulturalValue { get; set; }
        public modelDescription Description { get; set; }
        public modelGPSLocation GpsLocation { get; set; }
        public modelImage Image { get; set; }
        public modelMaterial Material { get; set; }
        public modelPlacement Placement { get; set; }
        public modelStatue Statue { get; set; }
        public modelStatueType StatueType { get; set; }
        public modelZipcode Zipcode { get; set; }
   

        #region Singleton
        private static StatueSingleton _instance;
        public static StatueSingleton Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new StatueSingleton();
                }
                return _instance;
            }
        }

#endregion
        private StatueSingleton()
        {
            
        }
    }
}
