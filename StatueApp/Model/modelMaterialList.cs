namespace StatueApp.Model
{
    public class modelMaterialList
    {
        public int Id { get; set; }
        public int FK_Statue { get; set; }
        public int FK_Material { get; set; }
    }
}
