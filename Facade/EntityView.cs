using System.ComponentModel.DataAnnotations;

namespace Facade;
public abstract class EntityView
{
    [Required] public int Id { get; set; }
}
