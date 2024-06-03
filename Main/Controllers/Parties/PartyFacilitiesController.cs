using Aids.Methods;
using Data.Parties;
using Domain.Parties;
using Domain.Repos.Parties;
using Facade.Parties;

namespace Main.Controllers.Parties;
public class PartyFacilitiesController(IPartyFacilityRepo r) : 
    BaseController<PartyFacility, PartyFacilityView>(r)
{
    protected override PartyFacility toModel(PartyFacilityView v) => 
        new PartyFacility(Copy.Members<PartyFacilityView, PartyFacilityData>(v));
}