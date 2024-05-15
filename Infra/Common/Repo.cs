using Data;
using Domain;
using Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace Infra.Common;
public abstract class Repo<TEntity, TData>(DbContext c, DbSet<TData> s) : 
    PagedRepo<TEntity, TData>(c, s), IPagedRepo<TEntity> 
    where TEntity : Entity<TData>
    where TData : EntityData, new()
{
}
