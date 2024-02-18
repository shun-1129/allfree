using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace allfree.DBClassLibrary.Entities.Master
{
    [Table("m_sex")]
    public class m_sex : DbColumnBase
    {
        /// <summary>
        /// 性別マスタID
        /// </summary>
        [Key]
        public int m_sex_id { get; set; }

        /// <summary>
        /// 性別情報
        /// </summary>
        [Required]
        public string sex_info { get; set; } = string.Empty;

        /// <summary>
        /// 論理削除
        /// </summary>
        [Required]
        public bool is_deleted { get; set; }
    }
}
