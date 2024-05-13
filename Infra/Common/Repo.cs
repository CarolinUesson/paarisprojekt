using Data;
using Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace Infra.Common;
public abstract class Repo<TEntity>(DbContext c, DbSet<TEntity> s) : 
    PagedRepo<TEntity>(c, s), IPagedRepo<TEntity> where TEntity : EntityData, new()
{
}
