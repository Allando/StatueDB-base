namespace WebService
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ImageList")]
    public partial class ImageList
    {
        public int Id { get; set; }

        public int FK_Statue { get; set; }

        public int FK_Image { get; set; }

        public virtual Image Image { get; set; }

        public virtual Statue Statue { get; set; }
    }
}
