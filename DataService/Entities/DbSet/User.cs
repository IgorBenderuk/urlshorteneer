using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DataService.Entities.DbSet
{
    public class User
    {
        public Guid Id { get; set; } = new Guid();

        public string Email { get; set; } = string.Empty;

        public string  FirstName { get; set; }= string.Empty;

        public string LastName { get; set; } = string.Empty;

        public Role Role { get; set; } = Role.User;

        public string Passord { get; set; } = string.Empty;

        public virtual ICollection<Link> Links { get; set; }= new List<Link>();

        public DateTime CreationDate { get; set; } = DateTime.UtcNow;

        public DateTime UpdationDate { get; set; } = DateTime.UtcNow;
    }

}
