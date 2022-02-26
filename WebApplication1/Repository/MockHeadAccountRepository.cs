using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Interfaces;
using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public class MockHeadAccountRepository : IHeadAccountRepository
    {
        private readonly AppDbContext _context;

        public MockHeadAccountRepository(AppDbContext appDbContext)
        {
            this._context = appDbContext;
        }

        public async Task<List<HeadAccountsInformations>> All()
        {
            try
            {
                var headAccounts = await _context.HeadAccountsInformations.Where(x => x.IsActive == true).Include("ControlAccountInformations").Include("UserInformation").ToListAsync();
                return headAccounts;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<HeadAccountsInformations> Delete(int Id)
        {
            try
            {
                var headAccounts = await _context.HeadAccountsInformations.Include("ControlAccountInformations").Include("UserInformation").FirstOrDefaultAsync(x => x.Id == Id);
                _context.Remove(headAccounts);
                await _context.SaveChangesAsync();

                return headAccounts;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<HeadAccountsInformations> GetById(int Id)
        {
            try
            {
                var headAccounts = await _context.HeadAccountsInformations.Include("ControlAccountInformations").Include("UserInformation").FirstOrDefaultAsync(x => x.Id == Id);
                return headAccounts;
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
                var Count = await _context.HeadAccountsInformations.Where(x => x.HeadAccountTitle == Name && x.IsActive == true).CountAsync();

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

        public async Task<HeadAccountsInformations> Insert(HeadAccountsInformations headAccountsInformations)
        {
            try
            {
                await _context.AddAsync(headAccountsInformations);
                await _context.SaveChangesAsync();

                HeadAccountsInformations headAccount = new HeadAccountsInformations();

                if (headAccountsInformations.Id > 0)
                {
                    headAccount = await _context.HeadAccountsInformations.FirstOrDefaultAsync(x => x.Id == headAccountsInformations.Id);
                    return headAccount;
                }
                else
                {
                    return headAccountsInformations;
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<HeadAccountsInformations> Update(HeadAccountsInformations headAccountsInformations)
        {
            try
            {
                var headAccount = _context.HeadAccountsInformations.Attach(headAccountsInformations);
                headAccount.State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return headAccountsInformations;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> GetCodeByHeadAccountId(int Id)
        {
            try
            {
                int Code = 0;
                Code  = await _context.HeadAccountsInformations.Where(x => x.ControlAccountId == Id).Select(x => x.Code).LastOrDefaultAsync();
                return Code;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> GetCodeByHeadAccountIdForAccount(int Id)
        {
            try
            {
                int Code = 0;
                Code = await _context.HeadAccountsInformations.Where(x => x.Id == Id).Select(x => x.Code).LastOrDefaultAsync();
                return Code;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
