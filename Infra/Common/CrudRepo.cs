using Data;
using Domain;
using Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace Infra.Common;
public abstract class CrudRepo<TEntity, TData>(DbContext c, DbSet<TData> s) : 
    BaseRepo, ICrudRepo<TEntity> 
    where TEntity : Entity<TData> 
    where TData : EntityData, new()
{
    internal readonly DbContext db = c;
    internal readonly DbSet<TData> set = s;
    internal TEntity? item;
    internal readonly List<TEntity> list = [];
    protected abstract TEntity toEntity(TData? d);

    public async Task<bool> AddAsync(TEntity obj)
    {
        try
        {
            await set.AddAsync(obj.Data);
            await db.SaveChangesAsync();
            return true;
        }
        catch
        {
            db.ChangeTracker.Clear();
            return false;
        }
    }
    public async Task<bool> DeleteAsync(int id)
    {
        try
        {
            var model = await getAsync(id);
            if (model != null) set.Remove(model);
            await db.SaveChangesAsync();
            return true;
        }
        catch
        {
            db.ChangeTracker.Clear();
            return false;
        }
    }

    public async Task<IEnumerable<TData>> getAsync() => await createSQL().AsNoTracking().ToListAsync(); 
    public async Task<IEnumerable<TEntity>> GetAsync() => (await getAsync()).Select(toEntity);
    
    protected internal virtual IQueryable<TData> createSQL() => from s in set select s;
    public async Task<TData?> getAsync(int? id) => await set.FirstOrDefaultAsync(m => m.Id == id);
    public async Task<TEntity?> GetAsync(int? id) => toEntity(await getAsync(id));

    public async Task<bool> UpdateAsync(TEntity obj)
    {
        if (obj is null) return false;
        if (!isInDbSet(obj.Id)) return false;
        try
        {
            set.Update(obj.Data);
            await db.SaveChangesAsync();
            return true;
        }
        catch
        {
            db.ChangeTracker.Clear();
            return false;
        }
    }
    private bool isInDbSet(int id) => set.Any(e => e.Id == id);
}
