using StatueApp.Interface;

namespace StatueApp.Model
{
    public class modelImageList : IWebUri, IGetByStatueId
    {
        public modelImageList()
        {
            ResourceUri = "ImageLists";
            VerboseName = "List of Images";
            CanGetByStatueId = true;
        }

        public modelImageList(int fkStatue, int fkImage) : this()
            // Constructs Object with parameters AND the content of the Default Constructor
        {
            FK_Statue = fkStatue;
            FK_Image = fkImage;
        }

        public modelImageList(int id, int fkStatue, int fkImage) : this()
            // Constructs Object with parameters AND the content of the Default Constructor
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