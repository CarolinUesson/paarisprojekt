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
    public async Task<dynamic?> SelectItem(int id)
    {
        var list = await selectList(id);
        return list.FirstOrDefault();
    }
    public async Task<IEnumerable<dynamic>> SelectItems(string researchString, int id)
    {
        PageNumber = 1;
        SearchString = researchString;
        SortOrder = selectTextField;
        var list = (await getAsync()).ToList();
        return await selectList(id, list);
    }

    private async Task<SelectList> selectList(int id, List<TData>? list = null)
    {
        var l = list ?? [];
        var o = await getAsync(id);
        if (o != null && !l.Contains(o)) l.Add(o);
        return new SelectList(l, nameof(EntityData.Id), selectTextField, id);

    }
}
