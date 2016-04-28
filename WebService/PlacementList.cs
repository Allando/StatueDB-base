namespace WebService
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PlacementList")]
    public partial class PlacementList
    {
        public int Id { get; set; }

        public int FK_Statue { get; set; }

        public int FK_Placement { get; set; }

        public virtual Placement Placement { get; set; }

        public virtual Statue Statue { get; set; }
    }
}
