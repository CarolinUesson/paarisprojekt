using Domain.Common;

namespace Infra.Common;
public abstract class OrderedRepo<TEntity> : 
    FilteredRepo<TEntity>, IOrderedRepo<TEntity> where TEntity : class, new()
{
    public string SortOrder { get; set; } = string.Empty;
}
