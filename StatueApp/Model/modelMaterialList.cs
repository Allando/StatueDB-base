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

        public modelMaterialList(int id, int fkStatue, int fkMaterial) : this()
        {
            // Constructs Object with parameters AND the content of the Default Constructor
            Id = id;
            FK_Statue = fkStatue;
            FK_Material = fkMaterial;
        }
    }
}
