using Data.Pd;
using Domain;
using Domain.Pd;
using Domain.Repos;
using Infra.Common;

namespace Infra.Pd;
public class DeploymentsRepo(DepDbContext c):
    Repo<Deployment, DeploymentData>(c, c.Deployment), IDeploymentsRepo {
    protected override IQueryable<DeploymentData> addFilter(IQueryable<DeploymentData> sql) =>
        string.IsNullOrEmpty(SearchString)
        ? sql
        : sql.Where(s => (s.FromDate.ToString().Contains(SearchString))
     || s.ThruDate != null && s.ThruDate.ToString().Contains(SearchString));

    protected override Deployment toEntity(DeploymentData? d) => new(d);
}
