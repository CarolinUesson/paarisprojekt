using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Main.Models;

namespace Main.Controllers
{
    public class ProductFeaturesController : Controller
    {
        private readonly ProductFeatureDbContext _context;

        public ProductFeaturesController(ProductFeatureDbContext context)
        {
            _context = context;
        }

        // GET: ProductFeatures
        public async Task<IActionResult> Index()
        {
            return View(await _context.ProductFeature.ToListAsync());
        }

        // GET: ProductFeatures/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productFeature = await _context.ProductFeature
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productFeature == null)
            {
                return NotFound();
            }

            return View(productFeature);
        }

        // GET: ProductFeatures/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProductFeatures/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Description")] ProductFeature productFeature)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productFeature);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(productFeature);
        }

        // GET: ProductFeatures/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productFeature = await _context.ProductFeature.FindAsync(id);
            if (productFeature == null)
            {
                return NotFound();
            }
            return View(productFeature);
        }

        // POST: ProductFeatures/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Description")] ProductFeature productFeature)
        {
            if (id != productFeature.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productFeature);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductFeatureExists(productFeature.Id))
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
            return View(productFeature);
        }

        // GET: ProductFeatures/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productFeature = await _context.ProductFeature
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productFeature == null)
            {
                return NotFound();
            }

            return View(productFeature);
        }

        // POST: ProductFeatures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productFeature = await _context.ProductFeature.FindAsync(id);
            if (productFeature != null)
            {
                _context.ProductFeature.Remove(productFeature);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductFeatureExists(int id)
        {
            return _context.ProductFeature.Any(e => e.Id == id);
        }
    }
}
