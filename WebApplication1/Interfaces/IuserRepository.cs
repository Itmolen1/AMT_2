using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Interfaces
{
    public interface IUserRepository
    {
        Task<List<UserInformation>> All();
        Task<UserInformation> Insert(UserInformation userInformation);
        Task<UserInformation> GetById(int Id);
        Task<UserInformation> Update(UserInformation userInformation);
        Task<UserInformation> Delete(int Id);
    }
}
