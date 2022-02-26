using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Interfaces;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class TransictionController : Controller
    {
        private readonly ITransictionRepository _transictionRepository;
        private readonly ITrackUpdateRepository _trackUpdateRepository;
        private readonly IAccountRepository _accountRepository;

        public TransictionController(ITransictionRepository transictionRepository,
            ITrackUpdateRepository trackUpdateRepository,
            IAccountRepository accountRepository)
        {
            this._transictionRepository = transictionRepository;
            this._trackUpdateRepository = trackUpdateRepository;
            this._accountRepository = accountRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                var transictions = await _transictionRepository.All();
                return View(transictions);
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
                TransictionInformations transictionInformations = new TransictionInformations();
                //Test Transiction
                var rand = new Random();
                int RandomNumber = rand.Next(10, 50);
                int UniqueValue = RandomNumber;

                TransictionViewModel transictionViewModels = new TransictionViewModel();

                List<TransictionInformations> transictions = new List<TransictionInformations>();
                
                transictions.Add(new TransictionInformations()
                {
                    TransictionIdentity = RandomNumber,
                    IsActive = true,
                    ForDate = System.DateTime.Now,
                    AccountId = 1041,
                    Dr = 500, Cr = 0,
                    CreatedBy = 1,
                    CreatedDate = System.DateTime.Now,
                    Description = "Brought table for Office"
                });

                transictions.Add(new TransictionInformations()
                {
                    TransictionIdentity = RandomNumber,
                    IsActive = true,
                    ForDate = System.DateTime.Now,
                    AccountId = 1013,
                    Dr = 0,
                    Cr = 500,
                    CreatedBy = 1,
                    CreatedDate = System.DateTime.Now,
                    Description = "Brought table for Office"
                });

                var trn = await _transictionRepository.Insert(transictions);

                //foreach (var transiction in transictionViewModels.TransictionInformations)
                //{
                //    transiction.CreatedBy = 1;     
                //    transiction.CreatedDate = System.DateTime.Now;
                //    transiction.IsActive = true;

                //    //var InsertAccount = await _transictionInformations.Insert(transiction);
                //}

                //End Test
                //ViewBag.GetExpenseAccounts = await GetExpenseAccounts();
                return PartialView("_Create", transictionInformations);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(TransictionViewModel transictionViewModel)
        {
            try
            {
                var rand = new Random();
                int RandomNumber = rand.Next(10, 50);

                if (!ModelState.IsValid)
                {
                    ViewBag.GetExpenseAccounts = await GetExpenseAccounts();
                    return View("_Create", transictionViewModel);
                }
                else
                {

                    int UniqueValue = RandomNumber;
                    foreach (var transiction in transictionViewModel.TransictionInformations)
                    {
                        transiction.CreatedBy = 1;
                        transiction.CreatedDate = System.DateTime.Now;
                        transiction.IsActive = true;

                       // var InsertAccount = await _transictionInformations.Insert(transiction);
                    }
                    return RedirectToAction("_Journal", RandomNumber);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        
        [HttpGet]
        public async Task<IActionResult> Journal(int Id)
        {
            try
            {
                var accounts = await _transictionRepository.GetByUniqueIdentity(Id);
                return PartialView("_Journal", accounts);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [NonAction]
        public async Task<List<AccountsInformation>> GetExpenseAccounts()
        {
            try
            {
                var accounts = await _accountRepository.All();
                var ExpenseAccounts = accounts.Where(x => x.HeadAccountsInformations.ControlAccountInformations.Id == 6).ToList();
                return ExpenseAccounts;
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        public async Task<IActionResult> GeneralJournal()
        {
            try
            {
                var accounts = await _transictionRepository.All();
                return PartialView("_GeneralJournal", accounts);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        public async Task<IActionResult> TrailBalance()
        {
            try
            {
                var transictionTrails = await _transictionRepository.GetTrailBalance();
                return PartialView("_TrailBalance",transictionTrails);
            }
            catch (Exception)
            {
                throw;
            }
        }



    }
}