using Data.Pd;
using Microsoft.EntityFrameworkCore;
using Aids.Methods;

namespace Infra.Pd.Init;
public sealed class DeploymentDbInitializer(DbContext c, DbSet<DeploymentData> s) : DbInitializer<DeploymentData>(c, s)
{
    protected override void setValues(int idx)
    {
        if (item == null) return;
        item.FromDate = GetRnd.DateTime(DateTime.Now.AddYears(-20), DateTime.Now.AddYears(-5));
        item.ThruDate = GetRnd.DateTime(DateTime.Now.AddYears(-20), DateTime.Now.AddYears(-5));
    }
}
