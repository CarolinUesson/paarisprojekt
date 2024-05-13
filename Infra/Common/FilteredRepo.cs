using Data;
using Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace Infra.Common;
public abstract class FilteredRepo<TEntity>(DbContext c, DbSet<TEntity> s) : 
    CrudRepo<TEntity>(c, s), IFilteredRepo<TEntity> where TEntity : EntityData, new()
{
    public string SearchString { get; set; } = string.Empty;
    protected internal override IQueryable<TEntity> createSQL()
    {
        var sql = base.createSQL();
        sql = addFilter(sql);
        return sql;
    }

    protected abstract IQueryable<TEntity> addFilter(IQueryable<TEntity> sql);
}
