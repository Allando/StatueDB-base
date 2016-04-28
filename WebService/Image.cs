using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace WebService
{
    [Table("Image")]
    public class Image
    {
        [SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Image()
        {
            ImageLists = new HashSet<ImageList>();
        }

        public int Id { get; set; }

        [Column("Image")]
        [Required]
        [StringLength(50)]
        public string Image1 { get; set; }

        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ImageList> ImageLists { get; set; }
    }
}