using StatueApp.Interface;

namespace StatueApp.Model
{
    public class modelImageList: IWebUri
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
    }
}
