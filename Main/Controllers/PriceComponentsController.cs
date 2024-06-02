using Aids.Methods;
using Data.Pd;
using Domain;
using Domain.Pd;
using Domain.Repos;
using Facade.Pd;

namespace Main.Controllers;
public class PriceComponentsController(IPriceComponentsRepo r):
    BaseController<PriceComponent, PriceComponentView>(r) {
    protected override PriceComponent toModel(PriceComponentView v) =>
        new PriceComponent(Copy.Members<PriceComponentView, PriceComponentData>(v));
}
