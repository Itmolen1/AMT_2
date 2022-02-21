using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Interfaces;

namespace WebApplication1.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var users = await _userRepository.All();
                return View("List", users);
            }
            catch (Exception)
            {
                throw;
            }
         
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}