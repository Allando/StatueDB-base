using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace WebService
{
    [Table("Material")]
    public class Material
    {
        [SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Material()
        {
            MaterialLists = new HashSet<MaterialList>();
        }

        public int Id { get; set; }

        [Column("Material")]
        [Required]
        [StringLength(50)]
        public string Material1 { get; set; }

        [Required]
        [StringLength(1)]
        public string Types { get; set; }

        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MaterialList> MaterialLists { get; set; }
    }
}