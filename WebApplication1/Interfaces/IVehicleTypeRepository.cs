using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Interfaces
{
    public interface IVehicleTypeRepository
    {
        Task<List<VehicleTypeInformations>> All();
        Task<VehicleTypeInformations> Insert(VehicleTypeInformations vehicleTypeInformations);
        Task<VehicleTypeInformations> GetById(int Id);
        Task<VehicleTypeInformations> Update(VehicleTypeInformations vehicleTypeInformations);
        Task<VehicleTypeInformations> Delete(int Id);
        Task<bool> Exist(string Name);
    }
}
