using StatueApp.Interface;

namespace StatueApp.Model
{
    public class modelMaterial : IWebUri
    {
        public int Id { get; set; }
        public string Material1 { get; set; }
        public string Types { get; set; }
        public string ResourceUri { get; }
        public string VerboseName { get; }

        public modelMaterial()
        {
            ResourceUri = "Material";
            VerboseName = "Material";
        }
    }
}
