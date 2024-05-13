using Data;
using Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace Infra.Common;
public abstract class OrderedRepo<TEntity>(DbContext c, DbSet<TEntity> s) : 
    FilteredRepo<TEntity>(c, s), IOrderedRepo<TEntity> where TEntity : EntityData, new()
{
    public string SortOrder { get; set; } = string.Empty;
}
