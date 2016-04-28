namespace WebService
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GPSLocation")]
    public partial class GPSLocation
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Coordinates { get; set; }

        public int FK_Statue { get; set; }

        public virtual Statue Statue { get; set; }
    }
}
