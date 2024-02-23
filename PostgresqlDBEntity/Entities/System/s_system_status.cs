using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PostgresqlDBEntity.Entities.System
{
    /// <summary>
    /// システムステータステーブル
    /// </summary>
    [Table("s_system_status")]
    public class s_system_status : DbColumnBase
    {
        /// <summary>
        /// システムID
        /// </summary>
        [Key]
        [Required]
        public int system_id { get; set; }

        /// <summary>
        /// マスタテーブル更新日時
        /// </summary>
        [Required]
        public DateTime master_changed_date { get; set; }

        /// <summary>
        /// システムステータス
        /// </summary>
        [Required]
        public int system_status { get; set; }
    }
}
