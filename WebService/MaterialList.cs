namespace WebService
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MaterialList")]
    public partial class MaterialList
    {
        public int Id { get; set; }

        public int FK_Statue { get; set; }

        public int FK_Material { get; set; }

        public virtual Material Material { get; set; }

        public virtual Statue Statue { get; set; }
    }
}
