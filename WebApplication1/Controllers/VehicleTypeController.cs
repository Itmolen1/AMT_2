using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Interfaces;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class VehicleTypeController : Controller
    {
        private readonly IVehicleTypeRepository _vehicleTypeRepository;
        private readonly ITrackUpdateRepository _trackUpdateRepository;

        public VehicleTypeController(IVehicleTypeRepository vehicleTypeRepository, ITrackUpdateRepository trackUpdateRepository)
        {
            this._vehicleTypeRepository = vehicleTypeRepository;
            this._trackUpdateRepository = trackUpdateRepository;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var vehicleTypes = await _vehicleTypeRepository.All();
                return View(vehicleTypes);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            try
            {
                VehicleTypeInformations vehicleTypeInformations = new VehicleTypeInformations();

                return PartialView("_Create", vehicleTypeInformations);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(VehicleTypeInformations vehicleTypeInformations)
        {
            try
            {

                if (!ModelState.IsValid)
                {
                    return View("_Create",vehicleTypeInformations);
                }
                else
                {
                    if (vehicleTypeInformations.Id > 0)
                    {
                        vehicleTypeInformations.IsActive = true;
                        var vehicleTypeUpdate = await _vehicleTypeRepository.Update(vehicleTypeInformations);

                        //Track Update Model Start
                        var trackUpdateInformations = new TrackUpdateInformations
                        {
                            BeforeUpdate = vehicleTypeInformations.TypeName,
                            AfterUpdate = vehicleTypeInformations.TypeName,
                            UpdateInfo = vehicleTypeInformations.TypeName + "Changes",
                            CreatedBy = 1,
                            CreatedDate = System.DateTime.Now,
                            IsActive = true,
                        };

                        var result = await _trackUpdateRepository.Insert(trackUpdateInformations);
                        //Track Update Model End

                        return PartialView("_Details", vehicleTypeUpdate);
                    }
                    else
                    {
                        if (await _vehicleTypeRepository.Exist(vehicleTypeInformations.TypeName))
                        {
                            ModelState.AddModelError("Name", "The Department with this name " + vehicleTypeInformations.TypeName + " already exist");
                            return View();
                        }
                        else
                        {

                            vehicleTypeInformations.CreatedBy = 1;
                            vehicleTypeInformations.CreatedDate = System.DateTime.Now;
                            vehicleTypeInformations.IsActive = true;

                            var department = await _vehicleTypeRepository.Insert(vehicleTypeInformations);
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
                var vehicleType = await _vehicleTypeRepository.GetById(Id);
                return PartialView("_Details", vehicleType);
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
                var vehicleType = await _vehicleTypeRepository.GetById(Id);
                return PartialView("_Create", vehicleType);
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
                var vehicleType = await _vehicleTypeRepository.GetById(Id);
                return PartialView("_Delete", vehicleType);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(VehicleTypeInformations vehicleTypeInformations)
        {
            try
            {

                if (vehicleTypeInformations != null)
                {
                    var vehicleType = await _vehicleTypeRepository.GetById(vehicleTypeInformations.Id);

                    vehicleType.IsActive = false;

                    await _vehicleTypeRepository.Update(vehicleType);

                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return PartialView("_Details", vehicleTypeInformations);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}