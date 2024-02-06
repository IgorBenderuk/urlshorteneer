using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.Entities.DTOS.RequestDto
{
    public class CreateLinkrRequest
    {

        public string LongUrl { get; set; } = string.Empty;

        public Guid UserId { get; set; }

    }
}
