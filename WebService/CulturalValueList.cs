namespace WebService
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CulturalValueList")]
    public partial class CulturalValueList
    {
        public int Id { get; set; }

        public int FK_Statue { get; set; }

        public int FK_CulturalValue { get; set; }

        public virtual Culturalvalue Culturalvalue { get; set; }

        public virtual Statue Statue { get; set; }
    }
}
