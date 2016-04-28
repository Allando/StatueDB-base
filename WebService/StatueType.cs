namespace WebService
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("StatueType")]
    public partial class StatueType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public StatueType()
        {
            StatueTypeLists = new HashSet<StatueTypeList>();
        }

        public int Id { get; set; }

        [Column("StatueType ")]
        [Required]
        [StringLength(50)]
        public string StatueType_ { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StatueTypeList> StatueTypeLists { get; set; }
    }
}
