using Domain.Common;

namespace Infra.Common;
public abstract class CrudRepo<TEntity> : BaseRepo, ICrudRepo<TEntity> where TEntity : class, new()
{
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

    public TEntity Get(int? id)
    {
        throw new NotImplementedException();
    }

    public bool Update(TEntity obj)
    {
        throw new NotImplementedException();
    }
}
