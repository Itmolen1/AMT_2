using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Interfaces;
using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public class MockUnitRepository : IUnitRepository
    {
        private readonly AppDbContext _context;

        public MockUnitRepository(AppDbContext appDbContext)
        {
            this._context = appDbContext;
        }

        public async Task<List<UnitInformations>> All()
        {
            try
            {
                var units = await _context.UnitInformations.Where(x => x.IsActive == true).Include("UserInformation").ToListAsync();
                return units;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<UnitInformations> Delete(int Id)
        {
            try
            {
                var unit = await _context.UnitInformations.FirstOrDefaultAsync(x => x.Id == Id);
                _context.Remove(unit);
                await _context.SaveChangesAsync();

                return unit;
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
                var Count = await _context.UnitInformations.Where(x => x.Name == Name && x.IsActive == true).CountAsync();

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

        public async Task<UnitInformations> GetById(int Id)
        {
            try
            {
                var unit = await _context.UnitInformations.Include("UserInformation").FirstOrDefaultAsync(x => x.Id == Id);
                return unit;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<UnitInformations> Insert(UnitInformations unitInformations)
        {
            try
            {
                await _context.AddAsync(unitInformations);
                await _context.SaveChangesAsync();

                UnitInformations informations = new UnitInformations();

                if (unitInformations.Id > 0)
                {
                    informations = await _context.UnitInformations.FirstOrDefaultAsync(x => x.Id == unitInformations.Id);
                    return informations;
                }
                else
                {
                    return unitInformations;
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<UnitInformations> Update(UnitInformations unitInformations)
        {
            try
            {
                var uniit = _context.UnitInformations.Attach(unitInformations);
                uniit.State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return unitInformations;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
