using Domain.Common;

namespace Infra.Common;
public abstract class Repo<TEntity> : 
    PagedRepo<TEntity>, IPagedRepo<TEntity> where TEntity : class, new()
{
}
