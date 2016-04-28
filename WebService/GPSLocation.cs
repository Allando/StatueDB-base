using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebService
{
    [Table("GPSLocation")]
    public class GPSLocation
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Coordinates { get; set; }

        public int FK_Statue { get; set; }

        public virtual Statue Statue { get; set; }
    }
}