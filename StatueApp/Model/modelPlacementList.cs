namespace StatueApp.Model
{
    class modelPlacementList
    {
        public int Id { get; set; }
        public int FK_Statue { get; set; }
        public int FK_Placement { get; set; }
    }
}
