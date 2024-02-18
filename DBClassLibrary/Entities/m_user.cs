using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DBClassLibrary.Entities
{
    [Table ( "m_user" )]
    public class m_user : DbColumnBase
    {
        /// <summary>
        /// ユーザマスタID
        /// </summary>
        [Key]
        [Required]
        public int m_user_id { get; set; }

        /// <summary>
        /// ユーザマスタ情報
        /// </summary>
        [Required]
        public string user_info { get; set; } = string.Empty;

        /// <summary>
        /// 論理削除
        /// </summary>
        [Required]
        public bool is_deleted { get; set; }
    }
}
