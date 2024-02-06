using DataService.Data;
using DataService.Repos.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace DataService.Repos
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly AppDbContext dbContext;

        public UnitOfWork(AppDbContext dbContext, ILoggerFactory loggerFactory,IHttpContextAccessor httpContext)
        {
            this.dbContext = dbContext;

            var logger = loggerFactory.CreateLogger("logs");
            UserRepo = new UserRepo(logger, dbContext);
            LinkRepo = new LinkRepo(logger, dbContext,httpContext);
        }

        public IUserRepo UserRepo { get; }

        public ILinkRepo LinkRepo { get; }

        public async Task<bool> CompleteAsync()
        {
            var result = await dbContext.SaveChangesAsync();
            return result > 0;
        }
    
        public void Dispose()
        {
            dbContext.Dispose();
        }
    }
}
