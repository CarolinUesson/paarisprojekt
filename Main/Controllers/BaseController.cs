using Data;
using Domain.Common;
using Microsoft.AspNetCore.Mvc;

namespace Main.Controllers;
public class BaseController<TModel>(IPagedRepo<TModel> r) :
    Controller where TModel : EntityData, new()
{
    protected readonly IPagedRepo<TModel> repo = r;

    public async Task<IActionResult> Index(string sortOrder, string searchString, int? pageNr)
    {
        repo.PageNumber = pageNr;
        repo.SearchString = searchString;
        repo.SortOrder = sortOrder;
        ViewBag.HasNextPage = repo.HasNextPage;
        ViewBag.HasPreviousPage = repo.HasPreviousPage;
        ViewBag.PageNumber = repo.PageNrAsInt;
        ViewBag.SearchString = repo.SearchString;
        ViewBag.SortOrder = repo.SortOrder;
        return View(await repo.GetAsync());
    }
    public async Task<IActionResult> Details(int? id)
    {
        var model = await repo.GetAsync(id);
        return model == null ? NotFound() : View(model);
    }
    public IActionResult Create() => View();
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(TModel model)
         => !ModelState.IsValid
            ? View(model)
            : await repo.AddAsync(model)
            ? RedirectToAction(nameof(Index))
            : View(model);
    public async Task<IActionResult> Edit(int? id)
    {
        var model = await repo.GetAsync(id);
        return model == null ? NotFound() : View(model);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(TModel model) =>
        !ModelState.IsValid 
        ? View(model) 
        : await repo.UpdateAsync(model) 
        ? RedirectToAction(nameof(Index)) 
        : View(model);
    public async Task<IActionResult> Delete(int? id)
    {
        var model = await repo.GetAsync(id);
        return model == null ? NotFound() : View(model);
    }
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id) => 
        await repo.DeleteAsync(id) 
        ? RedirectToAction(nameof(Index)) 
        : RedirectToAction(nameof(Delete), id);
    
}