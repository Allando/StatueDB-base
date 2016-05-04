using StatueApp.Interface;

namespace StatueApp.Model
{
    public class modelImageList : IWebUri
    {
        public int Id { get; set; }
        public int FK_Statue { get; set; }
        public int FK_Image { get; set; }
        public string ResourceUri { get; }
        public string VerboseName { get; }

        public modelImageList()
        {
            ResourceUri = "ImageList";
            VerboseName = "List of Images";
        }

        public modelImageList(int id, int fkStatue, int fkImage) : this()
        // Constructs Object with parameters AND the content of the Default Constructor
        {
            Id = id;
            FK_Statue = fkStatue;
            FK_Image = fkImage;
        }
    }
}
