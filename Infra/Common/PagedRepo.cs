using Domain.Common;

namespace Infra.Common;
public abstract class PagedRepo<TEntity> : 
    OrderedRepo<TEntity>, IPagedRepo<TEntity> where TEntity : class, new()
{
    public int PageIdx { get; set; }
    public int PageSize { get; set; }

    public int TotalPages => throw new NotImplementedException();

    public int TotalItems => throw new NotImplementedException();

    public bool HasNextPage => throw new NotImplementedException();

    public bool HasPreviousPage => throw new NotImplementedException();
}
