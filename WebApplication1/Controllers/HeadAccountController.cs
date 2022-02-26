using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Interfaces;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HeadAccountController : Controller
    {
        private readonly IHeadAccountRepository _headAccountRepository;
        private readonly IControlAccountRepository _controlAccountRepository;
        private readonly ITrackUpdateRepository _trackUpdateRepository;

        public HeadAccountController(IControlAccountRepository controlAccountRepository,
            ITrackUpdateRepository trackUpdateRepository,IHeadAccountRepository headAccountRepository)
        {
            this._controlAccountRepository = controlAccountRepository;
            this._trackUpdateRepository = trackUpdateRepository;
            this._headAccountRepository = headAccountRepository;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var headAccounts = await _headAccountRepository.All();
                return View(headAccounts);
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
                ViewBag.controlAccounts = await GetControlAccounts();

                HeadAccountsInformations headAccountsInformations = new HeadAccountsInformations();
                return PartialView("_Create", headAccountsInformations);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(HeadAccountsInformations headAccountsInformations)
        {
            try
            {

                if (!ModelState.IsValid)
                {
                    ViewBag.controlAccounts = await GetControlAccounts();
                    return View("_Create", headAccountsInformations);
                }
                else
                {
                    if (headAccountsInformations.Id > 0)
                    {
                        headAccountsInformations.IsActive = true;
                        var headAccountUpdate = await _headAccountRepository.Update(headAccountsInformations);

                        HeadAccountsInformations headAccount = new HeadAccountsInformations();
                        headAccount = await _headAccountRepository.GetById(headAccountsInformations.Id);

                        //Track Update Model Start
                        var trackUpdateInformations = new TrackUpdateInformations
                        {
                            BeforeUpdate = headAccountsInformations.HeadAccountTitle,
                            AfterUpdate = headAccountsInformations.HeadAccountTitle,
                            UpdateInfo = headAccountsInformations.HeadAccountTitle + "Changes",
                            CreatedBy = 1,
                            CreatedDate = System.DateTime.Now,
                            IsActive = true,
                        };

                        var result = await _trackUpdateRepository.Insert(trackUpdateInformations);
                        //Track Update Model End

                        return PartialView("_Details", headAccount);
                    }
                    else
                    {
                        if (await _headAccountRepository.Exist(headAccountsInformations.HeadAccountTitle))
                        {
                            ModelState.AddModelError("Name", "The Head Account with this name " + headAccountsInformations.HeadAccountTitle + " already exist");
                            return View();
                        }
                        else
                        {

                            headAccountsInformations.CreatedBy = 1;
                            headAccountsInformations.CreatedDate = System.DateTime.Now;
                            headAccountsInformations.IsActive = true;

                            var controlAccount = await _headAccountRepository.Insert(headAccountsInformations);
                            return PartialView("_Details", headAccountsInformations);
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
                var headAccounts = await _headAccountRepository.GetById(Id);
                return PartialView("_Details", headAccounts);
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
                ViewBag.controlAccounts = await GetControlAccounts();
                var headAccounts = await _headAccountRepository.GetById(Id);
                return PartialView("_Create", headAccounts);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetHeadAccountByControlAccount(int Id)
        {
            try
            {
                List<HeadAccountsInformations> headAccounts = new List<HeadAccountsInformations>();
                var HAccounts = await _headAccountRepository.All();
                headAccounts = HAccounts.Where(x => x.ControlAccountId == Id).ToList();

                return View("_HeadByControl",headAccounts);
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
                var headAccounts = await _headAccountRepository.GetById(Id);
                return PartialView("_Delete", headAccounts);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(HeadAccountsInformations headAccountsInformations)
        {
            try
            {

                if (headAccountsInformations != null)
                {
                    var headAccounts = await _headAccountRepository.GetById(headAccountsInformations.Id);

                    headAccounts.IsActive = false;

                    await _headAccountRepository.Update(headAccounts);

                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return PartialView("_Details", headAccountsInformations);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        [NonAction]
        public async Task<List<ControlAccountInformations>> GetControlAccounts()
        {
            try
            {
                List<ControlAccountInformations> controlAccounts = new List<ControlAccountInformations>();
                controlAccounts = await _controlAccountRepository.All();
                controlAccounts.Insert(0, new ControlAccountInformations() { Id=0,ControlAccountName ="Please Select Control Account" });
                return controlAccounts;
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> GetAccountCode(int ControlAccountId = 1)
        {
            try
            {
                int HeadAccountCode = 0;

                HeadAccountCode = await _headAccountRepository.GetCodeByHeadAccountId(ControlAccountId);               
                if (HeadAccountCode < 1)
                {
                    HeadAccountCode = await _controlAccountRepository.GetAccountCode(ControlAccountId);
                    if (HeadAccountCode == 101)
                    {
                        HeadAccountCode = HeadAccountCode + 900;
                    }
                    else if(HeadAccountCode == 201)
                    {
                        HeadAccountCode = HeadAccountCode + 1800;
                    }
                    else if (HeadAccountCode == 301)
                    {
                        HeadAccountCode = HeadAccountCode + 2700;
                    }
                    else if (HeadAccountCode == 401)
                    {
                        HeadAccountCode = HeadAccountCode + 3600;
                    }
                    else if (HeadAccountCode == 501)
                    {
                        HeadAccountCode = HeadAccountCode + 4500;
                    }
                }
                else
                {
                    HeadAccountCode = HeadAccountCode + 1;
                }
                
                return Json(HeadAccountCode);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}