using System.ComponentModel.DataAnnotations.Schema;

namespace WebService
{
    [Table("CulturalValueList")]
    public class CulturalValueList
    {
        public int Id { get; set; }

        public int FK_Statue { get; set; }

        public int FK_CulturalValue { get; set; }

        public virtual CulturalValue CulturalValue { get; set; }

        public virtual Statue Statue { get; set; }
    }
}