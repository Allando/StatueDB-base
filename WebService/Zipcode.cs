namespace WebService
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Zipcode")]
    public partial class Zipcode
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
