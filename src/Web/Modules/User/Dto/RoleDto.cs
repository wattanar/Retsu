using System;
using System.ComponentModel.DataAnnotations;

namespace Web.Modules.User.Dto
{
    public class RoleDto
    {
        public int Id { get; set; }
        public Guid Guid { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int IsActive { get; set; }

        [Required]
        public DateTime CreateAt { get; set; }
    }
}