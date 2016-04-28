using System.ComponentModel.DataAnnotations.Schema;

namespace WebService
{
    [Table("ImageList")]
    public class ImageList
    {
        public int Id { get; set; }

        public int FK_Statue { get; set; }

        public int FK_Image { get; set; }

        public virtual Image Image { get; set; }

        public virtual Statue Statue { get; set; }
    }
}