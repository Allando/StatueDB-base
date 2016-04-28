using System.ComponentModel.DataAnnotations.Schema;

namespace WebService
{
    [Table("MaterialList")]
    public class MaterialList
    {
        public int Id { get; set; }

        public int FK_Statue { get; set; }

        public int FK_Material { get; set; }

        public virtual Material Material { get; set; }

        public virtual Statue Statue { get; set; }
    }
}