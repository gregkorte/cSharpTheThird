using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BangazonWebApp.Data;
using BangazonWebApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BangazonWebApp.Controllers
{
    [Route("[controller]/[action]")]
    public class SettingsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public SettingsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [TempData]
        public string StatusMessage { get; set; }
        // GET: Settings
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View();
        }

        // GET: PaymentOptions
        public async Task<IActionResult> PaymentOptions()
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                throw new ApplicationException($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            var pt = _context.PaymentType.Where(p => p.User.Id == user.Id).ToList();

            SettingsViewModel model = new SettingsViewModel()
            {
                PaymentTypes = pt
            };

            return View(model);
        }
    }
}
