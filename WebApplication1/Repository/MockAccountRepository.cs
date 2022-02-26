using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Interfaces;
using WebApplication1.Models;


namespace WebApplication1.Repository
{
    public class MockAccountRepository : IAccountRepository
    {
        private readonly AppDbContext _context;

        public MockAccountRepository(AppDbContext appDbContext)
        {
            this._context = appDbContext;
        }

        public async Task<List<AccountsInformation>> All()
        {
            try
            {
                var accounts = await _context.AccountsInformations
                    .Where(x=>x.IsActive == true)
                    .Include("HeadAccountsInformations")
                    .Include(x=>x.HeadAccountsInformations.ControlAccountInformations)
                    .Include(x=>x.UserInformation)
                    .ToListAsync();

                return accounts;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<AccountsInformation> Delete(int Id)
        {
            try
            {
                var accounts = await _context.AccountsInformations.Include("HeadAccountsInformations").Include("UserInformation").FirstOrDefaultAsync(x => x.Id == Id);
                _context.Remove(accounts);
                await _context.SaveChangesAsync();

                return accounts;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<AccountsInformation> GetById(int Id)
        {
            try
            {
                var accounts = await _context.AccountsInformations.Include("HeadAccountsInformations").Include(x => x.HeadAccountsInformations.ControlAccountInformations).Include("UserInformation").FirstOrDefaultAsync(x => x.Id == Id);
                return accounts;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> Exist(string Name)
        {
            try
            {
                var Count = await _context.AccountsInformations.Where(x => x.AccountTitle == Name && x.IsActive == true).CountAsync();

                if (Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<int> GetAccountCode(int Id)
        {
            try
            {
                int Code = 0;
                Code = await _context.AccountsInformations.Where(x => x.HeadAccountId == Id).Select(x => x.Code).LastOrDefaultAsync();
                return Code;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<AccountsInformation> Insert(AccountsInformation accountsInformation)
        {
            try
            {
                await _context.AddAsync(accountsInformation);
                await _context.SaveChangesAsync();

                AccountsInformation accountsInfo = new AccountsInformation();

                if (accountsInformation.Id > 0)
                {
                    accountsInfo = await _context.AccountsInformations.FirstOrDefaultAsync(x => x.Id == accountsInformation.Id);
                    return accountsInfo;
                }
                else
                {
                    return accountsInformation;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<AccountsInformation> Update(AccountsInformation accountsInformation)
        {
            try
            {
                var account = _context.AccountsInformations.Attach(accountsInformation);
                account.State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return accountsInformation;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<AccountsInformation>> GetAccountByHeadAccount(int Id)
        {
            try
            {
                var accounts = await _context.AccountsInformations
                    .Where(x => x.HeadAccountId == Id)
                    .Include(x=>x.UserInformation)
                    .Include(x=>x.HeadAccountsInformations)
                    .Include(x=>x.HeadAccountsInformations.ControlAccountInformations)
                    .ToListAsync();
                return accounts;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
