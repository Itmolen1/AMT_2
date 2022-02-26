using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Interfaces;
using WebApplication1.Models;
using WebApplication1.Models.ViewModels;

namespace WebApplication1.Repository
{
    public class MockTransictionInformations : ITransictionRepository
    {
        private readonly AppDbContext _context;

        public MockTransictionInformations(AppDbContext appDbContext)
        {
            this._context = appDbContext;
        }

        public async Task<List<TransictionInformations>> All()
        {
            try
            {
                var transictions = await _context.TransictionInformations
                    .OrderByDescending(x => x.Id)
                    .Where(x => x.IsActive == true)
                    .Include(x => x.AccountsInformation)
                    .Include(x => x.AccountsInformation.HeadAccountsInformations)
                    .Include(x => x.AccountsInformation.HeadAccountsInformations.ControlAccountInformations)
                    .Include(x => x.UserInformation)                    
                    .ToListAsync();                  

                return transictions;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Task<TransictionInformations> Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<TransictionInformations> GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<TransictionInformations>> GetByUniqueIdentity(int Id)
        {
            try
            {
              var transictions =   await _context.TransictionInformations
                    .Where(x => x.TransictionIdentity == Id)
                    .Include(x=>x.AccountsInformation)
                    .Include(x=>x.UserInformation)
                    .ToListAsync();

                return transictions;

            }
            catch (Exception)
            {
                throw;
            }           
        }

        public async Task<List<TransictionInformations>> Insert(List<TransictionInformations> transictionInformations)
        {
            try
            {
                List<TransictionInformations> Transinformations = new List<TransictionInformations>();

                foreach (var transictions in transictionInformations)
                {
                    await _context.AddAsync(transictions);
                    await _context.SaveChangesAsync();

                    Transinformations.Add(transictions);
                }
                return Transinformations;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Task<TransictionInformations> Update(TransictionInformations transictionInformations)
        {
            throw new NotImplementedException();
        }

        public async Task<List<TransictionTrailBalance>> GetTrailBalance()
        {
            try
            {
                var transictionTrails = _context.TransictionInformations
                    .GroupBy(x=>x.AccountId)
                    .Select(x=>new TransictionTrailBalance()
                    {
                        Cr = x.Sum(p=>p.Cr),
                        Dr = x.Sum(p => p.Dr), 
                        AccountTitle = x.Select(p=>p.AccountsInformation.AccountTitle).FirstOrDefault(),
                        Code = x.Select(p => p.AccountsInformation.Code).FirstOrDefault(),
                        Id = x.Select(p => p.AccountsInformation.Code).FirstOrDefault()
                    }).ToListAsync();

                return await transictionTrails;
            }
            catch (Exception)
            {
                throw;
            }
            
        }
    }
}
