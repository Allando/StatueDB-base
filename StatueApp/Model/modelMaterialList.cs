using StatueApp.Interface;

namespace StatueApp.Model
{
    public class modelMaterialList : IWebUri, IGetByStatueId, IHasFkStatuecs
    {
        public modelMaterialList()
        {
            ResourceUri = "MaterialLists";
            VerboseName = "List of Materials";
            CanGetByStatueId = true;
        }

        public modelMaterialList(int fkStatue, int fkMaterial) : this()
        {
            // Konstrukerer objektet med parameterne og indholdet af standard contrutoren
            FK_Statue = fkStatue;
            FK_Material = fkMaterial;
        }

        public modelMaterialList(int id, int fkStatue, int fkMaterial) : this()
        {
            // Konstrukerer objektet med parameterne og indholdet af standard contrutoren
            Id = id;
            FK_Statue = fkStatue;
            FK_Material = fkMaterial;
        }

        public int Id { get; set; }
        public int FK_Statue { get; set; }
        public int FK_Material { get; set; }
        public bool CanGetByStatueId { get; }
        public string ResourceUri { get; }
        public string VerboseName { get; }
    }
}