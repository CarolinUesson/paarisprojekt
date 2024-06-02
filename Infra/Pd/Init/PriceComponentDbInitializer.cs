using Aids.Methods;
using Data.Pd;
using Microsoft.EntityFrameworkCore;

namespace Infra.Pd.Init;
public sealed class PriceComponentDbInitializer(DbContext c, DbSet<PriceComponentData> s): DbInitializer<PriceComponentData>(c, s) {
    protected override void setValues(int idx) {
        if (item == null) return;
        item.FromDate = GetRnd.DateTime(DateTime.Now.AddYears(-20), DateTime.Now.AddYears(-5));
        item.FromDate = GetRnd.DateTime(DateTime.Now.AddYears(-20), DateTime.Now.AddYears(-5));
        item.Price = 1000000M * idx;
    }
}
