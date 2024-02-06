using DataService.Entities.DbSet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.Entities.DTOS.RequestDto
{
    public class UpDateUserRequest
    {
        public Guid Id { get; set; }
        public string Email { get; set; } = string.Empty;

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string Passord { get; set; } = string.Empty;

        public string Role { get; set; }=string.Empty;
    }
}
