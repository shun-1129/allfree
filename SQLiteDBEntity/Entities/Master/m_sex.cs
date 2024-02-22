using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SQLiteDBEntity.Entities.Master
{
    [Table("m_sex")]
    public class m_sex : BaseEntityColumn
    {
        [Key]
        public int m_sex_id { get; set; }

        [Required]
        public string m_sex_name { get ; set; } = string.Empty;

        [Required]
        public bool is_deleted { get; set; } = false;
    }
}
