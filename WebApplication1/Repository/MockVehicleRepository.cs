using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Interfaces;
using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public class MockVehicleRepository : IVehicleRepository
    {
        private readonly AppDbContext _context;

        public MockVehicleRepository(AppDbContext appDbContext)
        {
            this._context = appDbContext;
        }

        public async Task<List<VehicleInformation>> All()
        {
            try
            {
                var vehicles = await _context.VehicleInformation.Where(x => x.IsActive == true).Include("UserInformation").Include("VehicleTypeInformations").ToListAsync();
                return vehicles;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<VehicleInformation> Delete(int Id)
        {
            try
            {
                var vehicle = await _context.VehicleInformation.FirstOrDefaultAsync(x => x.Id == Id);
                _context.Remove(vehicle);
                await _context.SaveChangesAsync();

                return vehicle;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<VehicleInformation> GetById(int Id)
        {
            try
            {
                var vehicle = await _context.VehicleInformation.Include("UserInformation").Include("VehicleTypeInformations").FirstOrDefaultAsync(x => x.Id == Id);
                return vehicle;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<VehicleInformation> Insert(VehicleInformation vehicleInformation)
        {
            try
            {
                await _context.AddAsync(vehicleInformation);
                await _context.SaveChangesAsync();

                VehicleInformation vehicle = new VehicleInformation();

                if (vehicleInformation.Id > 0)
                {
                    vehicle = await _context.VehicleInformation.Include("UserInformation").Include("VehicleTypeInformations").FirstOrDefaultAsync(x => x.Id == vehicleInformation.Id);
                    return vehicle;
                }
                else
                {
                    return vehicleInformation;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<VehicleInformation> Update(VehicleInformation vehicleInformation)
        {
            try
            {
                var vehicle = _context.VehicleInformation.Attach(vehicleInformation);
                vehicle.State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return vehicleInformation;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> Exist(string PlateNumber)
        {
            try
            {
                var Count = await _context.VehicleInformation.Where(x => x.PlateNumber == PlateNumber && x.IsActive == true).CountAsync();

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
        
    }
}
