using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Interfaces;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ControlAccountController : Controller
    {
        private readonly IControlAccountRepository _controlAccountRepository;
        private readonly ITrackUpdateRepository _trackUpdateRepository;

        public ControlAccountController(IControlAccountRepository controlAccountRepository, ITrackUpdateRepository trackUpdateRepository)
        {
            this._controlAccountRepository = controlAccountRepository;
            this._trackUpdateRepository = trackUpdateRepository;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var controlAccounts = await _controlAccountRepository.All();
                return View(controlAccounts);
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
                ControlAccountInformations controlAccountInformations = new ControlAccountInformations();

                return PartialView("_Create", controlAccountInformations);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(ControlAccountInformations controlAccountInformations)
        {
            try
            {

                if (!ModelState.IsValid)
                {
                    return View("_Create", controlAccountInformations);
                }
                else
                {
                    if (controlAccountInformations.Id > 0)
                    {
                        controlAccountInformations.IsActive = true;
                        var controlAccountUpdate = await _controlAccountRepository.Update(controlAccountInformations);

                        //Track Update Model Start
                        var trackUpdateInformations = new TrackUpdateInformations
                        {
                            BeforeUpdate = controlAccountInformations.ControlAccountName,
                            AfterUpdate = controlAccountInformations.ControlAccountName,
                            UpdateInfo = controlAccountInformations.ControlAccountName + "Changes",
                            CreatedBy = 1,
                            CreatedDate = System.DateTime.Now,
                            IsActive = true,
                        };

                        var result = await _trackUpdateRepository.Insert(trackUpdateInformations);
                        //Track Update Model End

                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        if (await _controlAccountRepository.Exist(controlAccountInformations.ControlAccountName))
                        {
                            ModelState.AddModelError("Name", "The Department with this name " + controlAccountInformations.ControlAccountName + " already exist");
                            return View();
                        }
                        else
                        {

                            controlAccountInformations.CreatedBy = 1;
                            controlAccountInformations.CreatedDate = System.DateTime.Now;
                            controlAccountInformations.IsActive = true;

                            var controlAccount = await _controlAccountRepository.Insert(controlAccountInformations);
                            return RedirectToAction(nameof(Index));
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
                var controlAccount = await _controlAccountRepository.GetById(Id);
                return PartialView("_Details", controlAccount);
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
                var controlAccount = await _controlAccountRepository.GetById(Id);
                return PartialView("_Create", controlAccount);
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
                var controlAccount = await _controlAccountRepository.GetById(Id);
                return PartialView("_Delete", controlAccount);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(ControlAccountInformations controlAccountInformations)
        {
            try
            {

                if (controlAccountInformations != null)
                {
                    var controlAccount = await _controlAccountRepository.GetById(controlAccountInformations.Id);

                    controlAccount.IsActive = false;

                    await _controlAccountRepository.Update(controlAccount);

                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return PartialView("_Details", controlAccountInformations);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}