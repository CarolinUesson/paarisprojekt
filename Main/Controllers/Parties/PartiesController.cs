using Aids.Methods;
using Data.Parties;
using Domain.Parties;
using Domain.Repos.Parties;
using Facade.Parties;

namespace Main.Controllers.Parties;
public class PartiesController(IPartyRepo r) : 
    BaseController<Party, PartyView>(r)
{
    protected override string selectItemTextField => nameof(PartyView.Name);
    protected override Party toModel(PartyView v) => 
        new Party(Copy.Members<PartyView, PartyData>(v));
    
}