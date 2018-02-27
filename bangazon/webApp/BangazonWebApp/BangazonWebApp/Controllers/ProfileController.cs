using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BangazonWebApp.Data;
using BangazonWebApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BangazonWebApp.Controllers
{
    [Route("[controller]/[action]")]
    public class ProfileController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public ProfileController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [TempData]
        public string StatusMessage { get; set; }

        // GET: Profile
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                throw new ApplicationException($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            var pt = _context.PaymentType.Where(p => p.User.Id == user.Id).ToList();

            var ord = _context.Order.Where(o => o.User.Id == user.Id).ToList();

            ProfileViewModel model = new ProfileViewModel();

            model.FirstName = user.FirstName;
            model.LastName = user.LastName;
            model.StreetAddress = user.StreetAddress;
            model.City = user.City;
            model.State = user.State;
            model.ZipCode = user.ZipCode;
            model.PhoneNumber = user.PhoneNumber;
            model.PaymentTypes = pt;
            model.Orders = ord;
            StatusMessage = StatusMessage;

            return View(model);
        }

        // GET: Profile/Edit
        public async Task<IActionResult> Edit(int id)
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                throw new ApplicationException($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            ProfileViewModel model = new ProfileViewModel
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                StreetAddress = user.StreetAddress,
                City = user.City,
                State = user.State,
                ZipCode = user.ZipCode,
                PhoneNumber = user.PhoneNumber,
                Email = user.Email
            };

            return View(model);
        }

        // POST: Profile/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <IActionResult> Edit(ProfileViewModel model)
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                throw new ApplicationException($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }
            
            user.LastName = model.LastName;
            user.StreetAddress = model.StreetAddress;
            user.City = model.City;
            user.State = model.State;
            user.ZipCode = model.ZipCode;
            user.PhoneNumber = model.PhoneNumber;

            try
            {
                // TODO: Add update logic here
                _context.Update(user);
                _context.SaveChanges();
                StatusMessage = "Your profile has been updated.";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}