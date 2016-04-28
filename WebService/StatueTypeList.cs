namespace WebService
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("StatueTypeList")]
    public partial class StatueTypeList
    {
        public int Id { get; set; }

        public int FK_Statue { get; set; }

        public int FK_StatueType { get; set; }

        public virtual Statue Statue { get; set; }

        public virtual StatueType StatueType { get; set; }
    }
}
