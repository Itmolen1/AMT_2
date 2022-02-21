using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Interfaces;
using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public class MockVenderRepository : IVenderRepository
    {
        private readonly AppDbContext _context;

        public MockVenderRepository(AppDbContext appDbContext)
        {
            this._context = appDbContext;
        }

        public async Task<List<VenderInformations>> All()
        {
            try
            {
                var venders = await _context.VenderInformations.Where(x => x.IsActive == true).Include("UserInformation").ToListAsync();
                return venders;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<VenderInformations> Delete(int Id)
        {
            try
            {
                var vender = await _context.VenderInformations.FirstOrDefaultAsync(x => x.Id == Id);
                _context.Remove(vender);
                await _context.SaveChangesAsync();

                return vender;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<VenderInformations> GetById(int Id)
        {
            try
            {
                var vender = await _context.VenderInformations.Include("UserInformation").FirstOrDefaultAsync(x => x.Id == Id);
                return vender;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<VenderInformations> Insert(VenderInformations venderInformations)
        {
            try
            {
                await _context.AddAsync(venderInformations);
                await _context.SaveChangesAsync();

                VenderInformations vender = new VenderInformations();

                if (venderInformations.Id > 0)
                {
                    vender = await _context.VenderInformations.FirstOrDefaultAsync(x => x.Id == venderInformations.Id);
                    return vender;
                }
                else
                {
                    return venderInformations;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> TrnExist(string Trn)
        {
            try
            {
                var Count = await _context.VenderInformations.Where(x => x.TRNNumber == Trn && x.IsActive == true).CountAsync();

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

        public async Task<VenderInformations> Update(VenderInformations venderInformations)
        {
            try
            {
                var vender = _context.VenderInformations.Attach(venderInformations);
                vender.State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return venderInformations;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
