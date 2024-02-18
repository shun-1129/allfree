using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace allfree.DBClassLibrary.Entities.Master
{
    [Table("m_language")]
    public class m_language : DbColumnBase
    {
        /// <summary>
        /// 言語マスタID
        /// </summary>
        [Key]
        public int m_language_id { get; set; }

        /// <summary>
        /// 言語名
        /// </summary>
        [Required]
        public string language_name { get; set; } = string.Empty;

        /// <summary>
        /// 論理削除
        /// </summary>
        [Required]
        public bool is_deleted { get; set; }
    }
}
