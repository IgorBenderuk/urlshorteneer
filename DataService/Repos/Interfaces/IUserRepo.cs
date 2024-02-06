using DataService.Entities.DbSet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.Repos.Interfaces
{
    public interface IUserRepo : IGenericRepo<User>
    {
    }
}
