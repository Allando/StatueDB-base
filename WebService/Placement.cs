using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace WebService
{
    [Table("Placement")]
    public class Placement
    {
        [SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Placement()
        {
            PlacementLists = new HashSet<PlacementList>();
        }

        public int Id { get; set; }

        [Column("Placement")]
        [Required]
        [StringLength(50)]
        public string Placement1 { get; set; }

        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PlacementList> PlacementLists { get; set; }
    }
}