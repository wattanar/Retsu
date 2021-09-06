using System;

namespace Web.Modules.User.Dto
{
    public class UserDto
    {
        public int Id { get; set; }
        public Guid Guid { get; set; }
        public string Username { get; set; }
        public int IsActive { get; set; }
    }
}