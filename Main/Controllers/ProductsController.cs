using Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Main.Controllers {
    public class ProductsController(ProductFeatureDbContext c): Controller {
        private readonly ProductFeatureDbContext context = c;
        public async Task<IActionResult> Index() => View(await context.Product.ToListAsync());
        public async Task<IActionResult> Details(int? id) {
            if (id == null) return NotFound();
            var product = await context.Product.FirstOrDefaultAsync(m => m.Id == id);
            if (product == null) return NotFound();
            return View(product);
        }
        public IActionResult Create() => View();
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] ProductData product) {
            if (ModelState.IsValid) {
                context.Add(product);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }
        public async Task<IActionResult> Edit(int? id) {
            if (id == null) return NotFound();
            var product = await context.Product.FindAsync(id);
            if (product == null) return NotFound();
            return View(product);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] ProductData product) {
            if (id != product.Id) return NotFound();
            if (ModelState.IsValid) {
                try {
                    context.Update(product);
                    await context.SaveChangesAsync();
                } catch (DbUpdateConcurrencyException) {
                    if (!ProductExists(product.Id)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }
        public async Task<IActionResult> Delete(int? id) {
            if (id == null) return NotFound();
            var product = await context.Product.FirstOrDefaultAsync(m => m.Id == id);
            if (product == null) return NotFound();
            return View(product);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id) {
            var product = await context.Product.FindAsync(id);
            if (product != null) context.Product.Remove(product);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        private bool ProductExists(int id) => context.Product.Any(e => e.Id == id);
    }
}
