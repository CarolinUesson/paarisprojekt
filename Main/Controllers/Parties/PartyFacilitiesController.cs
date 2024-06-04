using Aids.Methods;
using Data.Parties;
using Domain.Parties;
using Domain.Repos.Parties;
using Facade.Parties;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Main.Controllers.Parties;
public class PartyFacilitiesController(IPartyFacilityRepo r, IPartyRepo? p, IFacilityRepo? f) : BaseController<PartyFacility, PartyFacilityView>(r)
{
    private readonly IPartyRepo? pRepo = p;
    private readonly IFacilityRepo? fRepo = f;

    protected override PartyFacility toModel(PartyFacilityView v) => new(Copy.Members<PartyFacilityView, PartyFacilityData>(v));

    protected override async Task loadRelatedItems(PartyFacility? m)
    {
        await base.loadRelatedItems(m);
        if (pRepo is not null) ViewBag.Parties = await new PartiesController(pRepo).SelectListAsync();
        if (fRepo is not null) ViewBag.Facilities = await new FacilitiesController(fRepo).SelectListAsync();
    }
    //protected override string selectItemTextField => nameof(PartyFacility.PartyId);
    //protected override PartyFacility toModel(PartyFacilityView v) => 
    //    new PartyFacility(Copy.Members<PartyFacilityView, PartyFacilityData>(v));
    //protected override async Task loadRelatedItems(PartyFacility? model)
    //{
    //    await base.loadRelatedItems(model);
    //    if (pRepo is null) return;
    //    ViewBag.Parties = await new PartiesController(pRepo).SelectListAsync();
    //}
}