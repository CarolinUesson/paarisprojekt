using Aids.Methods;
using Data;
using Domain.Common;
using Facade;
using Facade.Parties;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Main.Controllers;
public abstract class BaseController<TModel, TView>(IPagedRepo<TModel> r) : Controller 
    where TModel : class 
    where TView : EntityView, new()
{
    protected readonly IPagedRepo<TModel> repo = r;
    protected abstract TModel toModel(TView v);
    protected virtual async Task loadRelatedItems(TModel? model) => await Task.CompletedTask;
    protected virtual TView toView(TModel m) => Copy.Members<TModel, TView>(m);
    protected virtual string selectItemTextField => nameof(EntityView.Id);
    protected internal async Task<SelectList> SelectListAsync()
    {
        repo.PageSize = repo.TotalItems;
        var parties = (await repo.GetAsync()).Select(toView);
        return new SelectList(parties, nameof(PartyView.Id), selectItemTextField);
    }
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
        await loadRelatedItems(model);
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