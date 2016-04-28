using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebService
{
    [Table("Zipcode")]
    public class Zipcode
    {
        [Key]
        [Column("Zipcode")]
        [StringLength(50)]
        public string Zipcode1 { get; set; }

        [Required]
        [StringLength(50)]
        public string City { get; set; }
    }
}