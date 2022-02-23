using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Interfaces;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class VehicleController : Controller
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly ITrackUpdateRepository _trackUpdateRepository;
        private readonly IVehicleTypeRepository _vehicleTypeRepository;

        public VehicleController(IVehicleRepository vehicleRepository, ITrackUpdateRepository trackUpdateRepository, IVehicleTypeRepository vehicleTypeRepository)
        {
            this._vehicleRepository = vehicleRepository;
            this._trackUpdateRepository = trackUpdateRepository;
            this._vehicleTypeRepository = vehicleTypeRepository;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var vehicles = await _vehicleRepository.All();
                return View(vehicles);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            try
            {
                ViewBag.vehicleTypes = await GetVehicleTypes();
                VehicleInformation vehicleInformation = new VehicleInformation();

                return PartialView("_Create", vehicleInformation);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(VehicleInformation vehicleInformation)
        {
            try
            {

                if (!ModelState.IsValid)
                {

                    ViewBag.vehicleTypes = await GetVehicleTypes();

                    return View("_Create", vehicleInformation);
                }
                else
                {
                    if (vehicleInformation.Id > 0)
                    {
                        vehicleInformation.IsActive = true;
                        var departmentUpdate = await _vehicleRepository.Update(vehicleInformation);

                        //Track Update Model Start
                        var trackUpdateInformations = new TrackUpdateInformations
                        {
                            BeforeUpdate = vehicleInformation.PlateNumber,
                            AfterUpdate = vehicleInformation.PlateNumber,
                            UpdateInfo = vehicleInformation.PlateNumber + "Changes",
                            CreatedBy = 1,
                            CreatedDate = System.DateTime.Now,
                            IsActive = true,
                        };

                        var result = await _trackUpdateRepository.Insert(trackUpdateInformations);
                        //Track Update Model End

                        return PartialView("_Details", departmentUpdate);
                    }
                    else
                    {
                        if (await _vehicleRepository.Exist(vehicleInformation.PlateNumber))
                        {
                            ModelState.AddModelError("Name", "The Plate Number" + vehicleInformation.PlateNumber + " already exist");
                            return View();
                        }
                        else
                        {
                            vehicleInformation.CreatedBy = 1;
                            vehicleInformation.CreatedDate = System.DateTime.Now;
                            vehicleInformation.IsActive = true;

                            var department = await _vehicleRepository.Insert(vehicleInformation);
                            return PartialView("_Details", department);
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        public async Task<IActionResult> Details(int Id)
        {
            try
            {
                var vehicle = await _vehicleRepository.GetById(Id);
                return PartialView("_Details", vehicle);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
            try
            {
                ViewBag.vehicleTypes = await GetVehicleTypes();

                var vehicle = await _vehicleRepository.GetById(Id);
                return PartialView("_Create", vehicle);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int Id)
        {
            try
            {
                var vehicle = await _vehicleRepository.GetById(Id);
                return PartialView("_Delete", vehicle);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(VehicleInformation vehicleInformation)
        {
            try
            {

                if (vehicleInformation != null)
                {
                    var vehicle = await _vehicleRepository.GetById(vehicleInformation.Id);

                    vehicle.IsActive = false;

                    await _vehicleRepository.Update(vehicle);

                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return PartialView("_Details", vehicleInformation);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        [NonAction]
        public async Task<List<VehicleTypeInformations>> GetVehicleTypes()
        {
            List<VehicleTypeInformations> vehicleTypeInformations = new List<VehicleTypeInformations>();

            vehicleTypeInformations = await _vehicleTypeRepository.All();
            vehicleTypeInformations.Insert(0,new VehicleTypeInformations() { Id = 0, TypeName="Please select Vehicle Type" });
            return vehicleTypeInformations;
        }

    }
}