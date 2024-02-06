using DataService.Entities.DbSet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.Entities.DTOS.ResponseDto
{
    public class UserResponse
    {
        public Guid Id { get; set; } = new Guid();

        public string Email { get; set; } = string.Empty;

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        //public Role Role { get; set; } = Role.User;
        public string Role { get; set; } =string.Empty;

        public string Passord { get; set; } = string.Empty;
    }
}
