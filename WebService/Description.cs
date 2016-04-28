using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebService
{
    [Table("Description")]
    public class Description
    {
        public int Id { get; set; }

        [Column("Description")]
        [Required]
        [StringLength(4000)]
        public string Description1 { get; set; }

        public int FK_Statue { get; set; }

        public virtual Statue Statue { get; set; }
    }
}