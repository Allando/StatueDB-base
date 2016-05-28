using StatueApp.Interface;

namespace StatueApp.Model
{
    public class modelImageList : IWebUri, IGetByStatueId, IHasFkStatuecs
    {
        public modelImageList()
        {
            ResourceUri = "ImageLists";
            VerboseName = "List of Images";
            CanGetByStatueId = true;
        }

        public modelImageList(int fkStatue, int fkImage) : this()
            // Konstrukerer objektet med parameterne og indholdet af standard contrutoren
        {
            FK_Statue = fkStatue;
            FK_Image = fkImage;
        }

        public modelImageList(int id, int fkStatue, int fkImage) : this()
            // Konstrukerer objektet med parameterne og indholdet af standard contrutoren
        {
            Id = id;
            FK_Statue = fkStatue;
            FK_Image = fkImage;
        }

        public int Id { get; set; }
        public int FK_Statue { get; set; }
        public int FK_Image { get; set; }
        public bool CanGetByStatueId { get; }
        public string ResourceUri { get; }
        public string VerboseName { get; }
    }
}