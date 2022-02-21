using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Interfaces;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class VenderController : Controller
    {
        private readonly IVenderRepository _venderRepository;
        private readonly ITrackUpdateRepository _trackUpdateRepository;

        public VenderController(IVenderRepository venderRepository, ITrackUpdateRepository trackUpdateRepository)
        {
            this._venderRepository = venderRepository;
            this._trackUpdateRepository = trackUpdateRepository;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var venders = await _venderRepository.All();
                return View(venders);
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
                VenderInformations venderInformations = new VenderInformations();

                return PartialView("_Create", venderInformations);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(VenderInformations venderInformations)
        {
            try
            {

                if (!ModelState.IsValid)
                {
                    return View("_Create", venderInformations);
                }
                else
                {
                    if (venderInformations.Id > 0)
                    {
                        venderInformations.IsActive = true;
                        var venderUpdate = await _venderRepository.Update(venderInformations);

                        //Track Update Model Start
                        var trackUpdateInformations = new TrackUpdateInformations
                        {
                            BeforeUpdate = venderInformations.CompanyName,
                            AfterUpdate = venderInformations.CompanyName,
                            UpdateInfo = venderInformations.CompanyName + "Changes",
                            CreatedBy = 1,
                            CreatedDate = System.DateTime.Now,
                            IsActive = true,
                        };

                        var result = await _trackUpdateRepository.Insert(trackUpdateInformations);
                        //Track Update Model End

                        return PartialView("_Details", venderUpdate);
                    }
                    else
                    {
                        if (await _venderRepository.TrnExist(venderInformations.TRNNumber))
                        {
                            ModelState.AddModelError("TRNNumber", "The TRN Number " + venderInformations.TRNNumber + " already exist");
                            return View("_Create", venderInformations);
                        }
                        else
                        {

                            venderInformations.CreatedBy = 1;
                            venderInformations.CreatedDate = System.DateTime.Now;
                            venderInformations.IsActive = true;

                            var customer = await _venderRepository.Insert(venderInformations);
                            return PartialView("_Details", customer);
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
                var vender = await _venderRepository.GetById(Id);
                return PartialView("_Details", vender);
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
                var vender = await _venderRepository.GetById(Id);
                return PartialView("_Create", vender);
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
                var vender = await _venderRepository.GetById(Id);
                return PartialView("_Delete", vender);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(VenderInformations venderInformations)
        {
            try
            {

                if (venderInformations != null)
                {
                    var vender = await _venderRepository.GetById(venderInformations.Id);

                    vender.IsActive = false;

                    await _venderRepository.Update(vender);

                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return PartialView("_Details", venderInformations);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}