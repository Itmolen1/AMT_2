using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Interfaces;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class BloodGroupController : Controller
    {

        private readonly IBloodGroupRepository _bloodGroupRepository;
        private readonly ITrackUpdateRepository _trackUpdateRepository;

        public BloodGroupController(IBloodGroupRepository bloodGroupRepository, ITrackUpdateRepository trackUpdateRepository)
        {
            this._bloodGroupRepository = bloodGroupRepository;
            this._trackUpdateRepository = trackUpdateRepository;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var bloodGroups = await _bloodGroupRepository.All();
                return View(bloodGroups);
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
                BloodGroupInformations BloodGroup = new BloodGroupInformations();
                return PartialView("_Create", BloodGroup);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(BloodGroupInformations bloodGroupInformations)
        {
            try
            {

                if (!ModelState.IsValid)
                {
                    return View(bloodGroupInformations);
                }
                else
                {
                    if (bloodGroupInformations.Id > 0)
                    {
                        bloodGroupInformations.IsActive = true;
                        var bloodGroupUpdate = await _bloodGroupRepository.Update(bloodGroupInformations);

                        //Track Update Model Start
                        var trackUpdateInformations = new TrackUpdateInformations
                        {
                            BeforeUpdate = bloodGroupInformations.Name,
                            AfterUpdate = bloodGroupInformations.Name,
                            UpdateInfo = bloodGroupInformations.Name + "Changes",
                            CreatedBy = 1,
                            CreatedDate = System.DateTime.Now,
                            IsActive = true,
                        };

                        var result = await _trackUpdateRepository.Insert(trackUpdateInformations);
                        //Track Update Model End

                        return PartialView("_Details", bloodGroupUpdate);
                    }
                    else
                    {
                        if (await _bloodGroupRepository.Exist(bloodGroupInformations.Name))
                        {
                            ModelState.AddModelError("Name", "The Department with this name " + bloodGroupInformations.Name + " already exist");
                            return View();
                        }
                        else
                        {

                            bloodGroupInformations.CreatedBy = 1;
                            bloodGroupInformations.CreatedDate = System.DateTime.Now;
                            bloodGroupInformations.IsActive = true;

                            var bloodGroup = await _bloodGroupRepository.Insert(bloodGroupInformations);
                            return PartialView("_Details", bloodGroup);
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
                var bloodGroup = await _bloodGroupRepository.GetById(Id);
                return PartialView("_Details", bloodGroup);
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
                var bloodGroup = await _bloodGroupRepository.GetById(Id);
                return PartialView("_Create", bloodGroup);
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
                var bloodGroup = await _bloodGroupRepository.GetById(Id);
                return PartialView("_Delete", bloodGroup);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(BloodGroupInformations bloodGroupInformations)
        {
            try
            {

                if (bloodGroupInformations != null)
                {
                    var blood = await _bloodGroupRepository.GetById(bloodGroupInformations.Id);

                    blood.IsActive = false;

                    await _bloodGroupRepository.Update(blood);

                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return PartialView("_Details", bloodGroupInformations);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}