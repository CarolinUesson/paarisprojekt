using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Facade.Pd;
public sealed class DeploymentView: EntityView {
    [DisplayName("FromDate")][Required] public DateTime FromDate { get; set; }
    [DisplayName("ThruDate")][Required] public DateTime? ThruDate { get; set; }

}