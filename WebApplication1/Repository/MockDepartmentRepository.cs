using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Interfaces;
using WebApplication1.Models;


namespace WebApplication1.Repository
{
    public class MockDepartmentRepository : IDepartmentRepository
    {
        private readonly AppDbContext _context;

        public MockDepartmentRepository(AppDbContext appDbContext)
        {
            this._context = appDbContext;
        }

        public async Task<List<DepartmentInformations>> All()
        {
            try
            {
                var departments = await _context.DepartmentInformations.Where(x => x.IsActive == true).Include("UserInformation").ToListAsync();
                return departments;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<DepartmentInformations> Delete(int Id)
        {
            try
            {
                var department = await _context.DepartmentInformations.FirstOrDefaultAsync(x => x.Id == Id);
                _context.Remove(department);
                await _context.SaveChangesAsync();

                return department;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<DepartmentInformations> GetById(int Id)
        {
            try
            {
                var department = await _context.DepartmentInformations.Include("UserInformation").FirstOrDefaultAsync(x => x.Id == Id);
                return department;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<DepartmentInformations> Insert(DepartmentInformations departmentInformations)
        {
            try
            {
                 await _context.AddAsync(departmentInformations);
                 await _context.SaveChangesAsync();

                DepartmentInformations department = new DepartmentInformations();

                if(departmentInformations.Id > 0)
                {
                    department =await _context.DepartmentInformations.FirstOrDefaultAsync(x => x.Id == departmentInformations.Id);
                    return department;
                }
                else
                {
                    return departmentInformations;
                }
                 
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<DepartmentInformations> Update(DepartmentInformations departmentInformations)
        {
            try
            {
                var department = _context.DepartmentInformations.Attach(departmentInformations);
                department.State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return departmentInformations;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> Exist(string Name)
        {
            try
            {
                var Count = await _context.DepartmentInformations.Where(x => x.Name == Name && x.IsActive == true).CountAsync();

                if(Count > 0)
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
    }
}
