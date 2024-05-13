using Aids.Methods;
using Data.Pd;
using Microsoft.EntityFrameworkCore;

namespace Infra.Pd.Init;
public sealed class ProductFeatureDbInitializer(DbContext c, DbSet<ProductFeatureData> s) : DbInitializer<ProductFeatureData>(c, s)
{
    protected override void setValues(int idx)
    {
        if (item == null) return;
        item.Description = $"Description {idx}: " + GetRnd.String();
    }
}
