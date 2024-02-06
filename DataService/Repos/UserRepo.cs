using DataService.Data;
using DataService.Entities.DbSet;
using DataService.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DataService.Repos
{
    public class UserRepo(ILogger logger, AppDbContext dbContext) : GenericRepo<User>(logger, dbContext), IUserRepo
    {
        public override async Task<IEnumerable<User>> GetAll()
        {
            try
            {
                return await dbSet.ToListAsync();

            }
            catch (Exception ex)
            {
                logger.LogError(ex, $" Error Occurs in {nameof(UserRepo)} while processing  {GetAll} method  entity");
                throw;
            }
        }

        public override async Task<bool> Delete(Guid Id)
        {
            try
            {
                var user = await GetSingle(Id);
                if (user == null)
                {
                    return false;
                }
                dbSet.Remove(user);
                return true;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $" Error Occurs in {nameof(UserRepo)} while processing  {Delete} method  entity");
                return false;
            }

        }

        public override async Task<bool> Update(User user)
        {
            try
            {

                var availableUser = await GetSingle(user.Id);
                if (availableUser == null)
                {
                    return false;
                }
                availableUser.FirstName = user.FirstName;
                availableUser.LastName = user.LastName;
                availableUser.Email = user.Email;
                availableUser.Passord = user.Passord;
                availableUser.Role = user.Role;
                return true;

            }
            catch (Exception ex)
            {
                logger.LogError(ex, $" Error Occurs in {nameof(UserRepo)} while processing  {Update} method  entity");
                throw;
            }
        }
    }
}
