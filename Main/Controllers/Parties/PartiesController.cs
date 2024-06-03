using Aids.Methods;
using Data.Parties;
using Domain.Parties;
using Domain.Repos.Parties;
using Facade.Parties;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Main.Controllers.Parties;
public class PartiesController(IPartyRepo r) : 
    BaseController<Party, PartyView>(r)
{
    protected override Party toModel(PartyView v) => 
        new Party(Copy.Members<PartyView, PartyData>(v));

    internal async Task<SelectList> SelectListAsync()
    {
        repo.PageSize = repo.TotalItems;
        var parties = (await repo.GetAsync()).Select(toView);
        return new SelectList(parties, nameof(PartyView.Id), nameof(PartyView.Name));
    }
}