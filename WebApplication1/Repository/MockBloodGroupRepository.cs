using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Interfaces;
using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public class MockBloodGroupRepository : IBloodGroupRepository
    {
        private readonly AppDbContext _context;

        public MockBloodGroupRepository(AppDbContext appDbContext)
        {
            this._context = appDbContext;
        }

        public async Task<List<BloodGroupInformations>> All()
        {
            try
            {
                var bloodGroups = await _context.BloodGroupInformations.Where(x => x.IsActive == true).Include("UserInformation").ToListAsync();
                return bloodGroups;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<BloodGroupInformations> Delete(int Id)
        {
            try
            {
                var bloodGroup = await _context.BloodGroupInformations.FirstOrDefaultAsync(x => x.Id == Id);
                _context.Remove(bloodGroup);
                await _context.SaveChangesAsync();

                return bloodGroup;
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
                var Count = await _context.BloodGroupInformations.Where(x => x.Name == Name && x.IsActive == true).CountAsync();

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

        public async Task<BloodGroupInformations> GetById(int Id)
        {
            try
            {
                var bloodGroup = await _context.BloodGroupInformations.Include("UserInformation").FirstOrDefaultAsync(x => x.Id == Id);
                return bloodGroup;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<BloodGroupInformations> Insert(BloodGroupInformations bloodGroupInformations)
        {
            try
            {
                await _context.AddAsync(bloodGroupInformations);
                await _context.SaveChangesAsync();

                BloodGroupInformations bloodGroup = new BloodGroupInformations();

                if (bloodGroupInformations.Id > 0)
                {
                    bloodGroup = await _context.BloodGroupInformations.FirstOrDefaultAsync(x => x.Id == bloodGroupInformations.Id);
                    return bloodGroup;
                }
                else
                {
                    return bloodGroupInformations;
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<BloodGroupInformations> Update(BloodGroupInformations bloodGroupInformations)
        {
            try
            {
                var bloodGroup = _context.BloodGroupInformations.Attach(bloodGroupInformations);
                bloodGroup.State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return bloodGroupInformations;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
