namespace WebService
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Description")]
    public partial class Description
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
