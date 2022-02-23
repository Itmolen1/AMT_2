using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Interfaces
{
    public interface IVehicleRepository
    {
        Task<List<VehicleInformation>> All();
        Task<VehicleInformation> Insert(VehicleInformation vehicleInformation);
        Task<VehicleInformation> GetById(int Id);
        Task<VehicleInformation> Update(VehicleInformation vehicleInformation);
        Task<VehicleInformation> Delete(int Id);
        Task<bool> Exist(string PlateNumber);
    }
}
