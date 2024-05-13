using Data;
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
    public bool Add(TEntity obj)
    {
        throw new NotImplementedException();
    }

    public bool Delete(int id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<TEntity> Get()
    {
        throw new NotImplementedException();
    }

    public TEntity? Get(int? id) => set.FirstOrDefault(m => m.Id == id);
    public async Task<TEntity?> GetAsync(int? id) => await set.FirstOrDefaultAsync(m => m.Id == id);

    public bool Update(TEntity obj)
    {
        throw new NotImplementedException();
    }
}
