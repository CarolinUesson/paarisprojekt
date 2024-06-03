using Aids.Methods;
using Data.Parties;
using Domain.Parties;
using Domain.Repos.Parties;
using Facade.Parties;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Main.Controllers.Parties;
public class PartyFacilitiesController(IPartyFacilityRepo r, IPartyRepo? pRepo = null) : 
    BaseController<PartyFacility, PartyFacilityView>(r)
{
    protected override string selectItemTextField => nameof(PartyFacility.PartyId);
    protected override PartyFacility toModel(PartyFacilityView v) => 
        new PartyFacility(Copy.Members<PartyFacilityView, PartyFacilityData>(v));
    protected override async Task loadRelatedItems(PartyFacility? model)
    {
        await base.loadRelatedItems(model);
        if (pRepo is null) return;
        ViewBag.Parties = await new PartiesController(pRepo).SelectListAsync();
    }
}