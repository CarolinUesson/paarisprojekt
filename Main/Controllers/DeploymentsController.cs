using Aids.Methods;
using Data.Pd;
using Domain;
using Domain.Pd;
using Domain.Repos;
using Facade.Pd;

namespace Main.Controllers;
public class DeploymentsController(IDeploymentsRepo r):
    BaseController<Deployment, DeploymentView>(r) {
    protected override Deployment toModel(DeploymentView v) =>
        new Deployment(Copy.Members<DeploymentView, DeploymentData>(v));
}