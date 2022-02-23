using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Interfaces;
using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public class MockVehicleTypeRepository : IVehicleTypeRepository
    {
        private readonly AppDbContext _context;

        public MockVehicleTypeRepository(AppDbContext appDbContext)
        {
            this._context = appDbContext;
        }

        public async Task<List<VehicleTypeInformations>> All()
        {
            try
            {
                var vehicleTypes = await _context.VehicleTypeInformations.Where(x => x.IsActive == true).Include("UserInformation").ToListAsync();
                return vehicleTypes;
            }
            catch (Exception)
            {
                throw;
            }
        }
        
        public async Task<VehicleTypeInformations> Delete(int Id)
        {
            try
            {
                var vehicleType = await _context.VehicleTypeInformations.FirstOrDefaultAsync(x => x.Id == Id);
                _context.Remove(vehicleType);
                await _context.SaveChangesAsync();

                return vehicleType;
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
                var Count = await _context.VehicleTypeInformations.Where(x => x.TypeName == Name && x.IsActive == true).CountAsync();

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

        public async Task<VehicleTypeInformations> GetById(int Id)
        {
            try
            {
                var vehicleType = await _context.VehicleTypeInformations.Include("UserInformation").FirstOrDefaultAsync(x => x.Id == Id);
                return vehicleType;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<VehicleTypeInformations> Insert(VehicleTypeInformations vehicleTypeInformations)
        {
            try
            {
                await _context.AddAsync(vehicleTypeInformations);
                await _context.SaveChangesAsync();

                VehicleTypeInformations vehicleType = new VehicleTypeInformations();

                if (vehicleTypeInformations.Id > 0)
                {
                    vehicleType = await _context.VehicleTypeInformations.Include("UserInformation").FirstOrDefaultAsync(x => x.Id == vehicleTypeInformations.Id);
                    return vehicleType;
                }
                else
                {
                    return vehicleTypeInformations;
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<VehicleTypeInformations> Update(VehicleTypeInformations vehicleTypeInformations)
        {
            try
            {
                var vehicleType  = _context.VehicleTypeInformations.Attach(vehicleTypeInformations);
                vehicleType.State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return vehicleTypeInformations;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
