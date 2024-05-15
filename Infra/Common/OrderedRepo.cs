using Data;
using Domain;
using Domain.Common;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Reflection;

namespace Infra.Common;
public abstract class OrderedRepo<TEntity, TData>(DbContext c, DbSet<TData> s) : 
    FilteredRepo<TEntity, TData>(c, s), IOrderedRepo<TEntity> 
    where TEntity : Entity<TData>
    where TData : EntityData, new()
{
    public string SortOrder { get; set; } = string.Empty;
    internal static string descStr => "_desc";
    internal string? propertyName => SortOrder?.Replace(descStr, string.Empty);
    internal PropertyInfo? propertyInfo => typeof(TData).GetProperty(propertyName ?? string.Empty);
    protected internal override IQueryable<TData> createSQL()
    {
        var sql = base.createSQL();
        var keySelector = createKeySelector();
        return addOrderedBy(sql, keySelector);
    }

    internal IQueryable<TData> addOrderedBy(IQueryable<TData> sql, Expression<Func<TData, object>>? keySelector)
    {
        if (keySelector is null) return sql;
        if (isDecending) return sql.OrderByDescending(keySelector);
        else return sql.OrderBy(keySelector);
    }

    private Expression<Func<TData, object>>? createKeySelector()
    {
        var pi = propertyInfo;
        if (pi is null) return null;
        var parameter = Expression.Parameter(typeof(TData), "x");
        var property = Expression.Property(parameter, pi);
        var body = Expression.Convert(property, typeof(object));
        return Expression.Lambda<Func<TData, object>>(body, parameter);
    }
    internal bool isDecending => SortOrder.EndsWith(descStr);
}
