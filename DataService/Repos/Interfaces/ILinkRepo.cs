using DataService.Entities.DbSet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.Repos.Interfaces
{
    public interface ILinkRepo : IGenericRepo<Link>
    {
        Task<IEnumerable<Link>?> GetUserLinks(Guid userId);

        public Task<Link?> GetUrlByShorten(string shortUrl);

        public Task<bool> LinkExis(Link link);
    }
}
