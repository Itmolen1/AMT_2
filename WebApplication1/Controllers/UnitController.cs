using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Interfaces;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class UnitController : Controller
    {
        private readonly IUnitRepository _unitRepository;
        private readonly ITrackUpdateRepository _trackUpdateRepository;

        public UnitController(IUnitRepository unitRepository, ITrackUpdateRepository trackUpdateRepository)
        {
          this._unitRepository = unitRepository;
          this._trackUpdateRepository = trackUpdateRepository;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var units = await _unitRepository.All();
                return View(units);
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
                UnitInformations unitInformations = new UnitInformations();

                return PartialView("_Create", unitInformations);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(UnitInformations unitInformations)
        {
            try
            {

                if (!ModelState.IsValid)
                {
                    return View(unitInformations);
                }
                else
                {
                    if (unitInformations.Id > 0)
                    {
                        unitInformations.IsActive = true;
                        var updateUnit = await _unitRepository.Update(unitInformations);

                        //Track Update Model Start
                        var trackUpdateInformations = new TrackUpdateInformations
                        {
                            BeforeUpdate = unitInformations.Name,
                            AfterUpdate = unitInformations.Name,
                            UpdateInfo = unitInformations.Name + "Changes",
                            CreatedBy = 1,
                            CreatedDate = System.DateTime.Now,
                            IsActive = true,
                        };

                        var result = await _trackUpdateRepository.Insert(trackUpdateInformations);
                        //Track Update Model End

                        return PartialView("_Details", updateUnit);
                    }
                    else
                    {
                        if (await _unitRepository.Exist(unitInformations.Name))
                        {
                            ModelState.AddModelError("Name", "The Department with this name " + unitInformations.Name + " already exist");
                            return View();
                        }
                        else
                        {

                            unitInformations.CreatedBy = 1;
                            unitInformations.CreatedDate = System.DateTime.Now;
                            unitInformations.IsActive = true;

                            var unit = await _unitRepository.Insert(unitInformations);
                            return PartialView("_Details", unit);
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
                var unit = await _unitRepository.GetById(Id);
                return PartialView("_Details", unit);
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
                var unit = await _unitRepository.GetById(Id);
                return PartialView("_Create", unit);
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
                var unit = await _unitRepository.GetById(Id);
                return PartialView("_Delete", unit);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(UnitInformations unitInformations)
        {
            try
            {

                if (unitInformations != null)
                {
                    var unit = await _unitRepository.GetById(unitInformations.Id);

                    unit.IsActive = false;

                    await _unitRepository.Update(unit);

                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return PartialView("_Details", unitInformations);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}