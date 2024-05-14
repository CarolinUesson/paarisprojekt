using Data;
using Domain.Common;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Reflection;

namespace Infra.Common;
public abstract class OrderedRepo<TEntity>(DbContext c, DbSet<TEntity> s) : 
    FilteredRepo<TEntity>(c, s), IOrderedRepo<TEntity> where TEntity : EntityData, new()
{
    public string SortOrder { get; set; } = string.Empty;
    internal static string descStr => "_desc";
    internal string? propertyName => SortOrder?.Replace(descStr, string.Empty);
    internal PropertyInfo? propertyInfo => typeof(TEntity).GetProperty(propertyName ?? string.Empty);
    protected internal override IQueryable<TEntity> createSQL()
    {
        var sql = base.createSQL();
        var keySelector = createKeySelector();
        return addOrderedBy(sql, keySelector);
    }

    internal IQueryable<TEntity> addOrderedBy(IQueryable<TEntity> sql, Expression<Func<TEntity, object>>? keySelector)
    {
        if (keySelector is null) return sql;
        if (isDecending) return sql.OrderByDescending(keySelector);
        else return sql.OrderBy(keySelector);
    }

    private Expression<Func<TEntity, object>>? createKeySelector()
    {
        var pi = propertyInfo;
        if (pi is null) return null;
        var parameter = Expression.Parameter(typeof(TEntity), "x");
        var property = Expression.Property(parameter, pi);
        var body = Expression.Convert(property, typeof(object));
        return Expression.Lambda<Func<TEntity, object>>(body, parameter);
    }
    internal bool isDecending => SortOrder.EndsWith(descStr);
}
