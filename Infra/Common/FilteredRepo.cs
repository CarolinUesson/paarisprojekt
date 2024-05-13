using Domain.Common;

namespace Infra.Common;
public abstract class FilteredRepo<TEntity> : 
    CrudRepo<TEntity>, IFilteredRepo<TEntity> where TEntity : class, new()
{
    public string SearchString { get; set; } = string.Empty;
}
