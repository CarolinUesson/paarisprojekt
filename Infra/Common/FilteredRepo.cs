using Data;
using Domain;
using Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace Infra.Common;
public abstract class FilteredRepo<TEntity, TData>(DbContext c, DbSet<TData> s) : 
    CrudRepo<TEntity, TData>(c, s), IFilteredRepo<TEntity> 
    where TEntity : Entity<TData>
    where TData : EntityData, new()
{
    public string SearchString { get; set; } = string.Empty;
    protected internal override IQueryable<TData> createSQL()
    {
        var sql = base.createSQL();
        sql = addFilter(sql);
        return sql;
    }

    protected abstract IQueryable<TData> addFilter(IQueryable<TData> sql);
}
