using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace DataService.Entities.DbSet
{
    public class Link
    {
        public Guid Id { get; set; } 

        public string LongUrl { get; set; } = string.Empty;

        public string ShortedUrl { get; set; } = string.Empty;

        public Guid UserId { get; set; }

        public virtual User? User { get; set; }

        public DateTime CreationDate { get; set; } = DateTime.UtcNow;

        public DateTime UpdationDate { get; set; } = DateTime.UtcNow;


    }
   
}