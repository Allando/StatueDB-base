using System.ComponentModel.DataAnnotations.Schema;

namespace WebService
{
    [Table("StatueTypeList")]
    public class StatueTypeList
    {
        public int Id { get; set; }

        public int FK_Statue { get; set; }

        public int FK_StatueType { get; set; }

        public virtual Statue Statue { get; set; }

        public virtual StatueType StatueType { get; set; }
    }
}