using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SQLiteDBEntity.Entities.System
{
    [Table( "s_master_edit_password" )]
    public class s_master_edit_password : BaseEntityColumn
    {
        [Key]
        public int system_id { get; set; }

        [Required]
        public string password { get; set; } = string.Empty;
    }
}
