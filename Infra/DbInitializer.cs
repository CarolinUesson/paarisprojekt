using Microsoft.EntityFrameworkCore;

namespace Infra;
public abstract class DbInitializer<TItem>(DbContext c, DbSet<TItem> s) where TItem : class, new()
{
    private readonly DbContext db = c;
    private readonly DbSet<TItem> set = s;
    protected TItem? item;
    private readonly List<TItem> list = [];
    protected abstract void setValues(int idx);
    private async Task save()
    {
        await set.AddRangeAsync(list);
        await db.SaveChangesAsync();
        list.Clear();
    }
    private bool canInit()
    {
        if (db is null) return false;
        if (set is null) return false;
        db.Database.EnsureCreated();
        return !set.Any();
    }
    public async Task Initialize(uint count)
    {
        if (!canInit()) return;
        try
        {
            for (var i = 1; i <= count; i++)
            {
                item = new TItem();
                setValues(i);
                list.Add(item);
                if (i % 10 != 0) continue;
                await save();
            }
        }
        finally
        {
            await save();
        }
    }
}
