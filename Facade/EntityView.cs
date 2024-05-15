using Domain;
using System.ComponentModel.DataAnnotations;

namespace Facade;
public abstract class EntityView : IEntity
{
    [Required] public int Id { get; set; }
}
