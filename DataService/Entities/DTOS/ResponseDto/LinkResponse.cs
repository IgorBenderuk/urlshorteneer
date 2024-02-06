using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.Entities.DTOS.ResponseDto
{
    public class LinkResponse
    {
        public  Guid Id { get; set; }

        public string LongUrl { get; set; } = string.Empty;

        public string ShortedUrl { get; set; } = string.Empty;

        public string CreatedBy {  get; set; } = string.Empty;  
    }
}
