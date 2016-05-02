namespace StatueApp.Model
{
    public class modelGPSLocation
    {
        public int Id { get; set; }

        public string Coordinates { get; set; }

        public int FK_Statue { get; set; }
    }
}
