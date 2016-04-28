using System.ComponentModel.DataAnnotations.Schema;

namespace WebService
{
    [Table("PlacementList")]
    public class PlacementList
    {
        public int Id { get; set; }

        public int FK_Statue { get; set; }

        public int FK_Placement { get; set; }

        public virtual Placement Placement { get; set; }

        public virtual Statue Statue { get; set; }
    }
}