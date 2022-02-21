using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Interfaces;
using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public class MockDesignationRepository : IDesignationRepository
    {
        private readonly AppDbContext _context;

        public MockDesignationRepository(AppDbContext appDbContext)
        {
            this._context = appDbContext;
        }

        public async Task<List<DesignationInformations>> All()
        {
            try
            {
                var designation = await _context.DesignationInformations.Where(x=>x.IsActive == true).Include("UserInformation").ToListAsync();
                return designation;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task<DesignationInformations> Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Exist(string Name)
        {
            try
            {
                var Count = await _context.DesignationInformations.Where(x => x.Name == Name && x.IsActive == true).CountAsync();

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

        public async Task<DesignationInformations> GetById(int Id)
        {
            try
            {
                var designation = await _context.DesignationInformations.Include("UserInformation").FirstOrDefaultAsync(x => x.Id == Id);
                return designation;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<DesignationInformations> Insert(DesignationInformations designationInformations)
        {
            try
            {
                await _context.AddAsync(designationInformations);
                await _context.SaveChangesAsync();

                DesignationInformations designation = new DesignationInformations();

                if (designationInformations.Id > 0)
                {
                    designation = await _context.DesignationInformations.Include("UserInformation").FirstOrDefaultAsync(x => x.Id == designationInformations.Id);
                    return designation;
                }
                else
                {
                    return designationInformations;
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<DesignationInformations> Update(DesignationInformations designationInformations)
        {
            try
            {
                var designation = _context.DesignationInformations.Attach(designationInformations);
                designation.State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return designationInformations;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
