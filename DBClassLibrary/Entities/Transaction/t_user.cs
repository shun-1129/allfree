using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace allfree.DBClassLibrary.Entities.Transaction
{
    /// <summary>
    /// 
    /// </summary>
    [Table ( "t_user" )]
    public class t_user : DbColumnBase
    {
        /// <summary>
        /// ID
        /// </summary>
        [Key]
        [Required]
        public long id { get; set; }

        /// <summary>
        /// ユーザID
        /// </summary>
        [Key]
        [Required]
        public string user_id { get; set; } = string.Empty;

        /// <summary>
        /// パスワード
        /// </summary>
        [Required]
        public string password { get; set; } = string.Empty;
    }
}
