using Aids.Methods;
using Data.Parties;
using Domain.Parties;
using Domain.Repos.Parties;
using Facade.Parties;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Main.Controllers.Parties;
public class PartyFacilitiesController(IPartyFacilityRepo r, IPartyRepo pRepo) : 
    BaseController<PartyFacility, PartyFacilityView>(r)
{
    protected override PartyFacility toModel(PartyFacilityView v) => 
        new PartyFacility(Copy.Members<PartyFacilityView, PartyFacilityData>(v));
    protected override async Task loadRelatedItems(PartyFacility? model)
    {
        await base.loadRelatedItems(model);
        pRepo.PageSize = pRepo.TotalItems;
        var par = await pRepo.GetAsync();
        ViewBag.Parties = new SelectList(par, nameof(Party.Id), nameof(Party.Name));
    }
}