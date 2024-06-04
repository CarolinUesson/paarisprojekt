using Aids.Methods;
using Data.Parties;
using Domain.Parties;
using Domain.Repos.Parties;
using Facade.Parties;

namespace Main.Controllers.Parties;
public class FacilitiesController(IFacilityRepo r) :
    BaseController<Facility, FacilityView>(r)
{
    protected override string selectItemTextField => nameof(FacilityView.Location);
    protected override Facility toModel(FacilityView v) =>
        new Facility(Copy.Members<FacilityView, FacilityData>(v));
}    