using Aids.Methods;
using Data.Parties;
using Domain.Parties;
using Domain.Repos.Parties;
using Facade.Parties;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Main.Controllers.Parties;
public class PartyFacilitiesController(IPartyFacilityRepo r, IPartyRepo pRepo = null) : 
    BaseController<PartyFacility, PartyFacilityView>(r)
{
    protected override PartyFacility toModel(PartyFacilityView v) => 
        new PartyFacility(Copy.Members<PartyFacilityView, PartyFacilityData>(v));
    protected override async Task loadRelatedItems(PartyFacility? model)
    {
        await base.loadRelatedItems(model);
        ViewBag.Parties = await new PartiesController(pRepo).SelectListAsync();
    }
    internal async Task<dynamic> SelectListAsync()
    {
        repo.PageSize = repo.TotalItems;
        var pf = (await repo.GetAsync()).Select(toView);
        return new SelectList(pf, nameof(PartyFacilityView.Id), nameof(PartyFacilityView.PartyId));
    }
}