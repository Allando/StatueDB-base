using StatueApp.Interface;

namespace StatueApp.Model
{
    public class modelImage : IWebUri
    {
        public modelImage()
        {
            ResourceUri = "Images";
            VerboseName = "Image";
        }

        public modelImage(string ImageUrl) : this()
            // Constructs Object with parameters AND the content of the Default Constructor
        {
            this.ImageUrl = ImageUrl;
        }

        public modelImage(int id, string imageUrl) : this()
            // Constructs Object with parameters AND the content of the Default Constructor
        {
            Id = id;
            ImageUrl = imageUrl;
        }

        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public string ResourceUri { get; }
        public string VerboseName { get; }
    }
}