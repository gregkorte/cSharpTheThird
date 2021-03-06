﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BangazonWebApp.Data;
using BangazonWebApp.Models;
using Microsoft.AspNetCore.Identity;
using System.Text.RegularExpressions;

namespace BangazonWebApp.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public ProductsController(UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Product.Include(p => p.ProductType);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .Include(p => p.ProductType)
                .SingleOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            ViewData["ProductTypeId"] = new SelectList(_context.ProductType, "ProductTypeId", "Label");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductId,Title,Description,DateCreated,Price,ProductTypeId,Location,ImagePath")] Product product)
        {
            ModelState.Remove("User");
            var p = new Product()
            {
                ProductId = product.ProductId,
                Title = product.Title,
                Description = product.Description,
                DateCreated = product.DateCreated,
                Price = product.Price,
                ProductTypeId = product.ProductTypeId,
                Location = product.Location,
                ImagePath = product.ImagePath,
                User = await _userManager.GetUserAsync(User)
            };

            if (ModelState.IsValid)
            {
                _context.Add(p);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", new { id = p.ProductId });
            }
            ViewData["ProductTypeId"] = new SelectList(_context.ProductType, "ProductTypeId", "Label", product.ProductTypeId);
            return View(product);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product.SingleOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["ProductTypeId"] = new SelectList(_context.ProductType, "ProductTypeId", "Label", product.ProductTypeId);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductId,Title,Description,DateCreated,Price,ProductTypeId,Location,ImagePath")] Product product)
        {
            if (id != product.ProductId)
            {
                return NotFound();
            }
            ModelState.Remove("User");
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.ProductId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductTypeId"] = new SelectList(_context.ProductType, "ProductTypeId", "Label", product.ProductTypeId);
            return View(product);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .Include(p => p.ProductType)
                .SingleOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Product.SingleOrDefaultAsync(m => m.ProductId == id);
            _context.Product.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Products/MyProducts
        [HttpGet]
        public async Task<IActionResult> MyProducts()
        {
            var myProducts = new List<MyProductsViewModel>();
            var user = await _userManager.GetUserAsync(User);
            var products = _context.Product.Where(p => p.User.Id == user.Id).ToList();

            foreach(var p in products)
            {
                var product = new MyProductsViewModel()
                {
                    Title = p.Title,
                    QuantityAvailable = 4,
                    QuantitySold = 3
                };

                myProducts.Add(product);
            }

            return View(myProducts);
        }

        // Post: Products/Search
        [HttpPost]
        public async Task<IActionResult> Search(string query)
        {
            if (query == null)
            {
                return NotFound("These aren't the products you are looking for.");
            }
            var Products = new List<Product>();
            var user = await _userManager.GetUserAsync(User);
            var qRegex = new Regex(@"(?i)" + query + "(?-i)");
            var products = _context.Product.Where(p => qRegex.IsMatch(p.Title)).ToList();

            foreach (var p in products)
            {
                var product = new Product()
                {
                    Title = p.Title,
                    Description = p.Description,
                    ImagePath = p.ImagePath,
                    Location = p.Location,
                    Price = p.Price,
                    Quantity = p.Quantity
                };

                Products.Add(product);
            }

            return View(Products);
        }

        private bool ProductExists(int id)
        {
            return _context.Product.Any(e => e.ProductId == id);
        }
    }
}
