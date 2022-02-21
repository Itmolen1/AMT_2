using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Interfaces;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class DesignationController : Controller
    {
        private readonly IDesignationRepository _designationRepository;
        private readonly ITrackUpdateRepository _trackUpdateRepository;

        public DesignationController(IDesignationRepository designation, ITrackUpdateRepository trackUpdate)
        {
            this._designationRepository = designation;
            this._trackUpdateRepository = trackUpdate;
        }
        
        [ActionName("Index")]
        public async Task<IActionResult> Index()
        {
            try
            {
                var designations = await _designationRepository.All();
                return View("List",designations);

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
                DesignationInformations designationInformations = new DesignationInformations();

                return PartialView("_Create", designationInformations);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(DesignationInformations designationInformations)
        {
            try
            {

                if (!ModelState.IsValid)
                {
                    return View("_Create",designationInformations);
                }
                else
                {
                    if (designationInformations.Id > 0)
                    {
                        designationInformations.IsActive = true;
                        var designationUpdate = await _designationRepository.Update(designationInformations);

                        //Track Update Model Start
                        var trackUpdateInformations = new TrackUpdateInformations
                        {
                            BeforeUpdate = designationInformations.Name,
                            AfterUpdate = designationInformations.Name,
                            UpdateInfo = designationInformations.Name + "Changes",
                            CreatedBy = 1,
                            CreatedDate = System.DateTime.Now,
                            IsActive = true,
                        };

                        var result = await _trackUpdateRepository.Insert(trackUpdateInformations);
                        //Track Update Model End

                        return PartialView("_Details", designationUpdate);
                    }
                    else
                    {
                        if (await _designationRepository.Exist(designationInformations.Name))
                        {
                            ModelState.AddModelError("Name", "The Designation with this name " + designationInformations.Name + " already exist");
                            return View("_Create", designationInformations);
                        }
                        else
                        {

                            designationInformations.CreatedBy = 1;
                            designationInformations.CreatedDate = System.DateTime.Now;
                            designationInformations.IsActive = true;

                            var designation = await _designationRepository.Insert(designationInformations);
                            return PartialView("_Details", designation);
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
                var designation = await _designationRepository.GetById(Id);
                return PartialView("_Details", designation);
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
                var designation = await _designationRepository.GetById(Id);
                return PartialView("_Create", designation);
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
                var designation = await _designationRepository.GetById(Id);
                return PartialView("_Delete", designation);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(DesignationInformations designationInformations)
        {
            try
            {

                if (designationInformations != null)
                {
                    var dep = await _designationRepository.GetById(designationInformations.Id);

                    dep.IsActive = false;

                    await _designationRepository.Update(dep);

                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return PartialView("_Details", designationInformations);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}