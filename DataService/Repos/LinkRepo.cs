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
            var url = $"https://localhost:7218/{shortUrl}";

          return  await dbSet.FirstOrDefaultAsync(l => l.ShortedUrl == url);
        }

        private  string  GenerateUniqueKey()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            Random random = new Random();
            string key = new string(Enumerable.Repeat(chars, 8).Select(s => s[random.Next(s.Length)]).ToArray());
            return key;
        }

        public override async Task<bool> Create(Link entity)
        {
             try
             {

                var isNewLink = await dbSet.AnyAsync(link => link.LongUrl == entity.LongUrl);
                if (isNewLink)
                    return false;
                
                var sUrl = $"https://localhost:7218/{GenerateUniqueKey()}";
                var newLink = new Link()
                {
                    LongUrl = entity.LongUrl,
                    ShortedUrl = sUrl,
                    UserId = entity.UserId,
                };

                await dbSet.AddAsync(newLink);

                return true;
             }
             catch (Exception ex)
             {
                logger.LogError(ex, $"Error Occurs in LinkRepo while processing Create method of {typeof(Link)} entity");
                throw;
             }
        }


    }
}
