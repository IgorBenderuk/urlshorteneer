using DataService.Data;
using DataService.Entities.DbSet;
using DataService.Repos.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using static System.Net.WebRequestMethods;

namespace DataService.Repos
{
    
    public class LinkRepo(ILogger logger, AppDbContext dbContext,IHttpContextAccessor httpContext) : GenericRepo<Link>(logger, dbContext), ILinkRepo
    {
        private readonly IHttpContextAccessor httpContext = httpContext;

        public async Task<IEnumerable<Link>?> GetUserLinks(Guid userId)
        {
            try
            {
                return await dbSet.Where(l => l.UserId == userId).ToListAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $" Error Occurs in linkRepo while processing  GetUserLinks method of {typeof(Link)} entity");
                throw;
            }

        }

        public override async Task<IEnumerable<Link>> GetAll()
        {
            try
            {
                return await dbSet.ToListAsync();

            }
            catch (Exception ex)
            {
                logger.LogError(ex, $" Error Occurs in LinkRepo while processing  GetAll method of {typeof(Link)} entity");
                throw;
            }


        }

        public override async Task<bool> Delete(Guid Id)
        {
            try
            {
                var link = await GetSingle(Id);
                if (link == null)
                {
                    return false;
                }
                dbSet.Remove(link);
                return true;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $" Error Occurs in LinkRepo while processing  Delete method of {typeof(Link)} entity");
                throw;
            }

        }


        public override async Task<bool> Update(Link entity)
        {
            try
            {

                var link = await GetSingle(entity.Id);

                if (link == null)
                {
                    return false;
                }
                link.LongUrl = entity.LongUrl;
                link.ShortedUrl = entity.ShortedUrl;
                return true;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $" Error Occurs in LinkRepo while processing  Update method of {typeof(Link)} entity");
                throw;
            }

        }


        public async Task<Link?> GetUrlByShorten(string shortUrl){
            var link=await dbSet.FirstOrDefaultAsync(l=>l.ShortedUrl == shortUrl );
            return link;
        }

        public async Task<bool> LinkExis(Link link)
        {
            return await dbSet.AnyAsync(l => l.LongUrl == link.LongUrl);
        }



    }
}
