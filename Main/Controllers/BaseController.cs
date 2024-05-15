using Aids.Methods;
using Data;
using Domain.Common;
using Microsoft.AspNetCore.Mvc;

namespace Main.Controllers;
public abstract class BaseController<TModel, TView>(IPagedRepo<TModel> r) : Controller 
    where TModel : class 
    where TView : class, new()
{
    protected readonly IPagedRepo<TModel> repo = r;
    protected abstract TModel toModel(TView v);
    protected virtual TView toView(TModel m) => Copy.Members<TModel, TView>(m);
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
        ViewBag.TotalPages = repo.TotalPages;
        var list = await repo.GetAsync();
        var viewList = list.Select(toView);
        return View(viewList);
    }
    public async Task<IActionResult> Details(int? id)
    {
        var model = await repo.GetAsync(id);
        return model == null ? NotFound() : View(toView(model));
    }
    public IActionResult Create() => View();
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(TView view)
         => !ModelState.IsValid
            ? View(view)
            : await repo.AddAsync(toModel(view))
            ? RedirectToAction(nameof(Index))
            : View(view);
    public async Task<IActionResult> Edit(int? id)
    {
        var model = await repo.GetAsync(id);
        return model == null ? NotFound() : View(toView(model));
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(TView view) =>
        !ModelState.IsValid 
        ? View(view) 
        : await repo.UpdateAsync(toModel(view)) 
        ? RedirectToAction(nameof(Index)) 
        : View(view);
    public async Task<IActionResult> Delete(int? id)
    {
        var model = await repo.GetAsync(id);
        return model == null ? NotFound() : View(toView(model));
    }
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id) => 
        await repo.DeleteAsync(id) 
        ? RedirectToAction(nameof(Index)) 
        : RedirectToAction(nameof(Delete), id);
    
}