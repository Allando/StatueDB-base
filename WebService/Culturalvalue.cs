namespace WebService
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Culturalvalue")]
    public partial class Culturalvalue
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Culturalvalue()
        {
            CulturalValueLists = new HashSet<CulturalValueList>();
        }

        public int Id { get; set; }

        [Column("CulturalValue")]
        [Required]
        [StringLength(50)]
        public string CulturalValue1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CulturalValueList> CulturalValueLists { get; set; }
    }
}
