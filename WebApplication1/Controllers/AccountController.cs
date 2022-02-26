using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Interfaces;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountRepository _accountRepository;
        private readonly ITrackUpdateRepository _trackUpdateRepository;
        private readonly IHeadAccountRepository _headAccountRepository;

        public AccountController(IAccountRepository accountRepository,
            ITrackUpdateRepository trackUpdateRepository, IHeadAccountRepository headAccountRepository)
        {
            this._accountRepository = accountRepository;
            this._trackUpdateRepository = trackUpdateRepository;
            this._headAccountRepository = headAccountRepository;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var accounts = await _accountRepository.All();
                return View(accounts);
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
                ViewBag.GetHeadAccounts = await GetHeadAccounts();

                AccountsInformation accountsInformation = new AccountsInformation();
                return PartialView("_Create", accountsInformation);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(AccountsInformation accountsInformation)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ViewBag.GetHeadAccounts = await GetHeadAccounts();
                    return View("_Create", accountsInformation);
                }
                else
                {
                    if (accountsInformation.Id > 0)
                    {
                        accountsInformation.IsActive = true;
                        var AccountUpdate = await _accountRepository.Update(accountsInformation);

                        AccountsInformation accounts = new AccountsInformation();
                        accounts = await _accountRepository.GetById(accountsInformation.Id);

                        //Track Update Model Start
                        var trackUpdateInformations = new TrackUpdateInformations
                        {
                            BeforeUpdate = accountsInformation.AccountTitle,
                            AfterUpdate = accountsInformation.AccountTitle,
                            UpdateInfo = accountsInformation.AccountTitle + "Changes",
                            CreatedBy = 1,
                            CreatedDate = System.DateTime.Now,
                            IsActive = true,
                        };

                        var result = await _trackUpdateRepository.Insert(trackUpdateInformations);
                        //Track Update Model End
                        return RedirectToAction("Details",new { accounts.Id});
                    }
                    else
                    {
                        if (await _accountRepository.Exist(accountsInformation.AccountTitle))
                        {
                            ModelState.AddModelError("AccountTitle", "The Head Account with this name " + accountsInformation.AccountTitle + " already exist");
                            return View();
                        }
                        else
                        {
                            accountsInformation.CreatedBy = 1;
                            accountsInformation.CreatedDate = System.DateTime.Now;
                            accountsInformation.IsActive = true;

                            var InsertAccount = await _accountRepository.Insert(accountsInformation);
                            return RedirectToAction("Details", new { InsertAccount.Id });
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
                var accounts = await _accountRepository.GetById(Id);
                return PartialView("_Details", accounts);
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
                ViewBag.GetHeadAccounts = await GetHeadAccounts();
                var accounts = await _accountRepository.GetById(Id);
                return PartialView("_Create", accounts);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [NonAction]
        public async Task<List<HeadAccountsInformations>> GetHeadAccounts()
        {
            try
            {
                List<HeadAccountsInformations> HeadAccounts = new List<HeadAccountsInformations>();
                HeadAccounts = await _headAccountRepository.All();
                HeadAccounts.Insert(0, new HeadAccountsInformations() { Id = 0, HeadAccountTitle = "Please Select Head Account" });
                return HeadAccounts;
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> GetAccountCode(int HeadAccountId = 1)
        {
            try
            {
                int AccountCode = 0;

                AccountCode = await _accountRepository.GetAccountCode(HeadAccountId);
                if (AccountCode < 1)
                {
                    AccountCode = await _headAccountRepository.GetCodeByHeadAccountIdForAccount(HeadAccountId);
                    string firstDigit = AccountCode.ToString().Substring(0, 3);
                    if (firstDigit == "100")
                    {
                        var AccountCodeSameControlDifferntHead = await _accountRepository.GetAccountCode(1);

                        AccountCode = AccountCode + 9000;
                    }
                    else if (firstDigit == "200")
                    {
                        AccountCode = AccountCode + 18000;
                    }
                    else if (firstDigit == "300")
                    {
                        AccountCode = AccountCode + 27000;
                    }
                    else if (firstDigit == "400")
                    {
                        AccountCode = AccountCode + 36000;
                    }
                    else if (firstDigit == "500")
                    {
                        AccountCode = AccountCode + 45000;
                    }
                }
                else
                {
                    //if (AccountCode.ToString().Length == 5)
                    //{
                    //    AccountCode = 90000 + 1;
                    //}
                    //else
                    //{
                        AccountCode = AccountCode + 1;
                    //}
                }

                return Json(AccountCode);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAccountByHeadAccountId(int Id)
        {
            try
            {
               var accounts = await _accountRepository.GetAccountByHeadAccount(Id);
                return PartialView("_AccountByHead",accounts);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}