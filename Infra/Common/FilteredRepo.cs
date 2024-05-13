using Data;
using Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace Infra.Common;
public abstract class FilteredRepo<TEntity>(DbContext c, DbSet<TEntity> s) : 
    CrudRepo<TEntity>(c, s), IFilteredRepo<TEntity> where TEntity : EntityData, new()
{
    public string SearchString { get; set; } = string.Empty;
}
