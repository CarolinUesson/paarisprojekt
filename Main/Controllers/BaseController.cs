using Data;
using Domain.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Main.Controllers;
public class BaseController<TModel>(ProductFeatureDbContext c, DbSet<TModel> s, IPagedRepo<TModel> r) : 
    Controller where TModel : EntityData, new()
{
    protected readonly ProductFeatureDbContext context = c;
    protected readonly DbSet<TModel> dbSet = s;
    protected readonly IPagedRepo<TModel> repo = r;

    public async Task<IActionResult> Index() => View(await dbSet.ToListAsync());
    public async Task<IActionResult> Details(int? id)
    {
        var model = await repo.GetAsync(id);
        return model == null ? NotFound() : View(model);
    }
    public IActionResult Create() => View();

    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null) return NotFound();
        var model = await dbSet.FindAsync(id);
        if (model == null) return NotFound();
        return View(model);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, TModel model)
    {
        if (id != model.Id) return NotFound();
        if (ModelState.IsValid)
        {
            try
            {
                context.Update(model);
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductFeatureExists(model.Id)) return NotFound();
                else throw;
            }
            return RedirectToAction(nameof(Index));
        }
        return View(model);
    }
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null) return NotFound();
        var model = await dbSet.FirstOrDefaultAsync(m => m.Id == id);
        if (model == null) return NotFound();
        return View(model);
    }
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var model = await dbSet.FindAsync(id);
        if (model != null) dbSet.Remove(model);
        await context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
    private bool ProductFeatureExists(int id) => dbSet.Any(e => e.Id == id);
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(TModel model)
    {
        if (ModelState.IsValid)
        {
            context.Add(model);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(model);
    }
    
}
