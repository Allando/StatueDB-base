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
            // Konstrukerer objektet med parameterne og indholdet af standard contrutoren
        {
            this.ImageUrl = ImageUrl;
        }

        public modelImage(int id, string imageUrl) : this()
            // Konstrukerer objektet med parameterne og indholdet af standard contrutoren
        {
            Id = id;
            ImageUrl = imageUrl;
        }

        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public string ResourceUri { get; }
        public string VerboseName { get; }

        public override string ToString()
        {
            return $"{ImageUrl}";
        }
    }
}