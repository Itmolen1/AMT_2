using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Interfaces
{
     public interface IHeadAccountRepository
    {
        Task<List<HeadAccountsInformations>> All();
        Task<HeadAccountsInformations> Insert(HeadAccountsInformations headAccountsInformations);
        Task<HeadAccountsInformations> GetById(int Id);
        Task<HeadAccountsInformations> Update(HeadAccountsInformations headAccountsInformations);
        Task<HeadAccountsInformations> Delete(int Id);
        Task<int> GetCodeByHeadAccountId(int Id);
        Task<int> GetCodeByHeadAccountIdForAccount(int Id);        
        Task<bool> Exist(string Name);
    }
}
