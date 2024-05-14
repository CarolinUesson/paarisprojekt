using Aids.Methods;
using Data.Pd;
using Microsoft.EntityFrameworkCore;

namespace Infra.Pd.Init;
public sealed class ProductDbInitializer(DbContext c, DbSet<ProductData> s) : DbInitializer<ProductData>(c, s)
{
    protected override void setValues(int idx)
    {
        if (item == null) return;
        item.Name = $"Name {idx}: " + GetRnd.String();
    }
}
