using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace WebService
{
    [Table("Statue")]
    public class Statue
    {
        [SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Statue()
        {
            CulturalValueLists = new HashSet<CulturalValueList>();
            Descriptions = new HashSet<Description>();
            GPSLocations = new HashSet<GPSLocation>();
            ImageLists = new HashSet<ImageList>();
            MaterialLists = new HashSet<MaterialList>();
            PlacementLists = new HashSet<PlacementList>();
            StatueTypeLists = new HashSet<StatueTypeList>();
        }

        public int Id { get; set; }

        public int Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Adress { get; set; }

        [Required]
        [StringLength(50)]
        public string Zipcode { get; set; }

        [Column(TypeName = "date")]
        public DateTime Created { get; set; }

        public DateTime Updated { get; set; }

        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CulturalValueList> CulturalValueLists { get; set; }

        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Description> Descriptions { get; set; }

        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GPSLocation> GPSLocations { get; set; }

        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ImageList> ImageLists { get; set; }

        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MaterialList> MaterialLists { get; set; }

        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PlacementList> PlacementLists { get; set; }

        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StatueTypeList> StatueTypeLists { get; set; }
    }
}