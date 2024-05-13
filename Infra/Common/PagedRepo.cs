using Data;
using Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace Infra.Common;
public abstract class PagedRepo<TEntity>(DbContext c, DbSet<TEntity> s) : 
    OrderedRepo<TEntity>(c, s), IPagedRepo<TEntity> where TEntity : EntityData, new()
{
    public int PageIdx { get; set; }
    public int PageSize { get; set; }

    public int TotalPages => throw new NotImplementedException();

    public int TotalItems => throw new NotImplementedException();

    public bool HasNextPage => throw new NotImplementedException();

    public bool HasPreviousPage => throw new NotImplementedException();
}
