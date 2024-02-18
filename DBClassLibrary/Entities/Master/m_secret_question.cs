using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace allfree.DBClassLibrary.Entities.Master
{
    [Table("m_secret_question")]
    public class m_secret_question : DbColumnBase
    {
        /// <summary>
        /// 秘密の質問マスタID
        /// </summary>
        [Key]
        [Required]
        public int m_secret_question_id { get; set; }

        /// <summary>
        /// 質問内容(日本語)
        /// </summary>
        [Required]
        public string question_content_jp { get; set; } = string.Empty;

        /// <summary>
        /// 質問内容(英語)
        /// </summary>
        public string? question_content_en { get; set; } = string.Empty;

        /// <summary>
        /// 論理削除
        /// </summary>
        [Required]
        public bool is_deleted { get; set; }
    }
}
