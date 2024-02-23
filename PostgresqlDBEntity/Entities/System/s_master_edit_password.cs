using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PostgresqlDBEntity.Entities.System
{
    [Table( "s_master_edit_password" )]
    public class s_master_edit_password : DbColumnBase
    {
        [Key]
        public int system_id { get; set; }

        [Required]
        public string password { get; set; } = string.Empty;
    }
}
