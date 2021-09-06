using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web.DataAccess.Entities
{
    [Table("UserRole")]
    public class UserRoleTable
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        public int RoleId { get; set; }

        public UserRoleTable User { get; set; }
        public RoleTable Role { get; set; }
    }
}