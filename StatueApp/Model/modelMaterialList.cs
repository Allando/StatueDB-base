using StatueApp.Interface;

namespace StatueApp.Model
{
    public class modelMaterialList:IWebUri
    {
        public int Id { get; set; }
        public int FK_Statue { get; set; }
        public int FK_Material { get; set; }
        public string ResourceUri { get; }
        public string VerboseName { get; }

        public modelMaterialList()
        {
            ResourceUri = "MaterialList";
            VerboseName = "List of Materials";
        }
    }
}
