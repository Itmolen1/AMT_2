using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Interfaces;
using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public class MockControlAccountRepository : IControlAccountRepository
    {
        private readonly AppDbContext _context;

        public MockControlAccountRepository(AppDbContext appDbContext)
        {
            this._context = appDbContext;
        }

        public async Task<List<ControlAccountInformations>> All()
        {
            try
            {
                var controlAccounts = await _context.ControlAccountInformations.Where(x => x.IsActive == true).Include("UserInformation").ToListAsync();
                return controlAccounts;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ControlAccountInformations> Delete(int Id)
        {
            try
            {
                var controlAccount = await _context.ControlAccountInformations.FirstOrDefaultAsync(x => x.Id == Id);
                _context.Remove(controlAccount);
                await _context.SaveChangesAsync();

                return controlAccount;
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
                var Count = await _context.ControlAccountInformations.Where(x => x.ControlAccountName == Name && x.IsActive == true).CountAsync();

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
                Code = await _context.ControlAccountInformations.Where(x => x.Id == Id).Select(x => x.Code).FirstOrDefaultAsync();
                return Code;                  
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ControlAccountInformations> GetById(int Id)
        {
            try
            {
                var controlAccount = await _context.ControlAccountInformations.Include("UserInformation").FirstOrDefaultAsync(x => x.Id == Id);
                return controlAccount;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ControlAccountInformations> Insert(ControlAccountInformations controlAccountInformations)
        {
            try
            {
                await _context.AddAsync(controlAccountInformations);
                await _context.SaveChangesAsync();

                ControlAccountInformations controlAccount = new ControlAccountInformations();

                if (controlAccountInformations.Id > 0)
                {
                    controlAccount = await _context.ControlAccountInformations.FirstOrDefaultAsync(x => x.Id == controlAccountInformations.Id);
                    return controlAccount;
                }
                else
                {
                    return controlAccountInformations;
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ControlAccountInformations> Update(ControlAccountInformations controlAccountInformations)
        {
            try
            {
                var controlAccount = _context.ControlAccountInformations.Attach(controlAccountInformations);
                controlAccount.State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return controlAccountInformations;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
