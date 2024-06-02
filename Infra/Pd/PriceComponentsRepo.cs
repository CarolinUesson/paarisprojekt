using Data.Pd;
using Domain;
using Domain.Pd;
using Domain.Repos;
using Infra.Common;

namespace Infra.Pd;
public class PriceComponentsRepo(DepDbContext c):
    Repo<PriceComponent, PriceComponentData>(c, c.PriceComponent), IPriceComponentsRepo {
    protected override IQueryable<PriceComponentData> addFilter(IQueryable<PriceComponentData> sql) =>
        string.IsNullOrEmpty(SearchString)
        ? sql
        : sql.Where(s => (s.FromDate.ToString().Contains(SearchString))
     || s.ThruDate.ToString().Contains(SearchString)
         || s.Price.ToString().Contains(SearchString)
        || s.Type != null && s.Type.Contains(SearchString));


    protected override PriceComponent toEntity(PriceComponentData? d) => new(d);
}
