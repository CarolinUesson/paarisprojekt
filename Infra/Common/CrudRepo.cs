using Data;
using Domain;
using Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace Infra.Common;
public abstract class CrudRepo<TEntity>(DbContext c, DbSet<TEntity> s) : 
    BaseRepo, ICrudRepo<TEntity> where TEntity : EntityData, new()
{
    internal readonly DbContext db = c;
    internal readonly DbSet<TEntity> set = s;
    internal TEntity? item;
    internal readonly List<TEntity> list = [];
   
    public async Task<bool> AddAsync(TEntity obj)
    {
        try
        {
            await set.AddAsync(obj);
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
        await Task.CompletedTask;
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<TEntity>> GetAsync() => await createSQL().AsNoTracking().ToListAsync(); 
    protected internal virtual IQueryable<TEntity> createSQL() => from s in set select s;
    public async Task<TEntity?> GetAsync(int? id) => await set.FirstOrDefaultAsync(m => m.Id == id);

    public async Task<bool> UpdateAsync(TEntity obj)
    {
        await Task.CompletedTask;
        throw new NotImplementedException();
    }

    
}
