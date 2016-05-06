using System.Collections.Generic;
using Windows.Networking.NetworkOperators;
using StatueApp.Facade;
using StatueApp.Model;

namespace StatueApp.ViewModel
{
    class viewmodelStatue
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

        StatueSingleton SingletonStatue;
        PlacmentSingleton SingletonPlacement;

        public viewmodelStatue()
        {
            SingletonStatue = StatueSingleton.Instance;
            SingletonPlacement = PlacmentSingleton.Instance;
        }

        /// <summary>
        /// Henter statue typer
        /// </summary>
        public async void GetStatueType()
        {
            IEnumerable<modelStatueType> listOfStatueTypes = await facadeStatue.GetListAsync(new modelStatueType());
            foreach (var item in listOfStatueTypes)
            {
                SingletonStatue.Add(item);
            }
        }

        /// <summary>
        /// Henter statue placement
        /// </summary>
        public async void GetStatuePlacement()
        {
            IEnumerable<modelPlacement> listOfPlacements = await facadeStatue.GetListAsync(new modelPlacement());
            foreach (var item in listOfPlacements)
            {
                SingletonPlacement.Add(item);
            }
        }
    }
}
