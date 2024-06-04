using Data;
using Domain;
using Domain.Common;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Infra.Common;
public abstract class Repo<TEntity, TData>(DbContext c, DbSet<TData> s) :
    PagedRepo<TEntity, TData>(c, s), IRepo<TEntity>
    where TEntity : Entity<TData>
    where TData : EntityData, new()
{
    protected internal virtual string selectTextField => nameof(EntityData.Id);
    public async Task<IEnumerable<dynamic>> SelectItems(string researchString, int id)
    {
        PageNumber = 1;
        SearchString = researchString;
        SortOrder = selectTextField;
        var list = await getAsync();
        return new SelectList(list, nameof(EntityData.Id), selectTextField, id);
    }
}
