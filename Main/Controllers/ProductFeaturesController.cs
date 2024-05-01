using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Data;

namespace Main.Controllers
{
    public class ProductFeaturesController(ProductFeatureDbContext c) : Controller
    {
        private readonly ProductFeatureDbContext context = c;
        public async Task<IActionResult> Index() => View(await context.ProductFeature.ToListAsync());
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            var productFeature = await context.ProductFeature.FirstOrDefaultAsync(m => m.Id == id);
            if (productFeature == null) return NotFound();
            return View(productFeature);
        }
        public IActionResult Create() => View(); 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Description")] ProductFeatureData productFeature)
        {
            if (ModelState.IsValid)
            {
                context.Add(productFeature);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(productFeature);
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var productFeature = await context.ProductFeature.FindAsync(id);
            if (productFeature == null) return NotFound();
            return View(productFeature);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Description")] ProductFeatureData productFeature)
        {
            if (id != productFeature.Id) return NotFound();
            if (ModelState.IsValid)
            {
                try
                {
                    context.Update(productFeature);
                    await context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductFeatureExists(productFeature.Id)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(productFeature);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var productFeature = await context.ProductFeature.FirstOrDefaultAsync(m => m.Id == id);
            if (productFeature == null) return NotFound();
            return View(productFeature);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productFeature = await context.ProductFeature.FindAsync(id);
            if (productFeature != null) context.ProductFeature.Remove(productFeature);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        private bool ProductFeatureExists(int id) => context.ProductFeature.Any(e => e.Id == id);
    }
}
