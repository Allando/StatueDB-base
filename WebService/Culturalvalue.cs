using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace WebService
{
    [Table("CulturalValue")]
    public class CulturalValue
    {
        [SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CulturalValue()
        {
            CulturalValueLists = new HashSet<CulturalValueList>();
        }

        public int Id { get; set; }

        [Column("CulturalValue")]
        [Required]
        [StringLength(50)]
        public string CulturalValue1 { get; set; }

        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CulturalValueList> CulturalValueLists { get; set; }
    }
}