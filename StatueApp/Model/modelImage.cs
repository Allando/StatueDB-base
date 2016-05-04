using StatueApp.Interface;

namespace StatueApp.Model
{
    public class modelImage : IWebUri
    {
        public int Id { get; set; }
        public string Image1 { get; set; }
        public string ResourceUri { get; }
        public string VerboseName { get; }

        public modelImage()
        {
            ResourceUri = "Image";
            VerboseName = "Image";
        }

        public modelImage(int id, string image1) : this()
        // Constructs Object with parameters AND the content of the Default Constructor
        {
            Id = id;
            Image1 = image1;
        }
    }
}
